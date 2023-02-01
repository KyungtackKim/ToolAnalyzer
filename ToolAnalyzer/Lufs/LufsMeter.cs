using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolAnalyzer.Lufs
{
    public class LufsMeter
    {
        private readonly LoudnessUpdatedHandler _momentaryLoudnessUpdated;
        private readonly LoudnessUpdatedHandler _shortTermLoudnessUpdated;

        private List<MeanSquareLoudness> _precedingMeanSquareLoudness;
        private double[] _shortTermMeanSquares;

        // Store mean squares of previous sample blocks (for short-term loudness)
        private int _shortTermMeanSquaresLength;

        /// <summary>
        ///     The constructor of the R128LufsMeter
        /// </summary>
        public LufsMeter() : this(0.4, 0.75, 3)
        {
            _momentaryLoudnessUpdated = null;
            _shortTermLoudnessUpdated = null;
        }

        private LufsMeter(double blockDuration, double overlap, double shortTermDuration)
        {
            BlockDuration = blockDuration;
            OverLap = overlap;
            StepDuration = BlockDuration * (1 - OverLap);
            ShortTermDuration = shortTermDuration;
        }

        // Buffer for calc mean square for current sample block (for momentary loudness) double[step][channel][sample]
        private double[][][] BlockBuffer { get; set; }
        private int NumChannel { get; set; }
        private int StepBufferPosition { get; set; }
        private double[][] StepBuffer { get; set; }

        // Common
        private double BlockDuration { get; }
        private double OverLap { get; }
        private double StepDuration { get; }
        private double ShortTermDuration { get; }
        private int BlockSampleCount { get; set; }
        private int StepSampleCount { get; set; }
        private int BlockStepCount { get; set; }
        private SecondOrderIirFilter PreFilter { get; set; }
        private SecondOrderIirFilter HighPassFilter { get; set; }

        /// <summary>
        ///     The integrated loudness started from the time when calling StartIntegrated
        /// </summary>
        public double IntegratedLoudness
        {
            get
            {
                if (_precedingMeanSquareLoudness == null) return double.NaN;

                // Gating of 400 ms blocks (overlapping by 75%), where two thresholds are used:
                //     The first at −70 LKFS;
                const double absoluteGateGamma = -70;
                var absoluteGatedLoudness = _precedingMeanSquareLoudness
                    .Where(loudness => loudness.Loudness > absoluteGateGamma).ToList();

                //      Calc relativeGateGamma
                var absoluteGatedMeanSquareSum = absoluteGatedLoudness.Sum(loudness => loudness.MeanSquare);
                var absoluteGatedMeanSquare = absoluteGatedMeanSquareSum / absoluteGatedLoudness.Count;
                var relativeGateGamma = -0.691 + 10 * Math.Log10(absoluteGatedMeanSquare) - 10;

                //     The second at −10 dB relative to the level measured after application of the first threshold.
                var relativeGatedLoudness = absoluteGatedLoudness
                    .Where(loudness => loudness.Loudness > relativeGateGamma).ToList();

                double relativeGatedMeanSquare = 0;
                double relativeGatedMeanSquareSum = 0;
                if (relativeGatedLoudness.Count > 0)
                {
                    relativeGatedMeanSquareSum += relativeGatedLoudness.Sum(loudness => loudness.MeanSquare);
                    relativeGatedMeanSquare = relativeGatedMeanSquareSum / relativeGatedLoudness.Count;
                }

                var integratedLoudness = -0.691 + 10 * Math.Log10(relativeGatedMeanSquare);
                return integratedLoudness;
            }
        }

        /// <summary>
        ///     Describe the current mode of integrated loudness
        /// </summary>
        private bool IsIntegrating { get; set; }

        /// <summary>
        ///     Prepare for process
        /// </summary>
        /// <param name="sampleRate">Sample rate of the sample data</param>
        /// <param name="numChannels">Number of channels of the sample data</param>
        public void Prepare(double sampleRate, int numChannels)
        {
            // init momentary loudness
            BlockSampleCount = (int)Math.Round(BlockDuration * sampleRate);
            StepSampleCount = (int)Math.Round(BlockSampleCount * (1 - OverLap));
            BlockStepCount = BlockSampleCount / StepSampleCount;

            NumChannel = numChannels;
            StepBufferPosition = 0;
            StepBuffer = new double[NumChannel][];
            for (var i = 0; i < StepBuffer.Length; i++) StepBuffer[i] = new double[StepSampleCount];
            BlockBuffer = new double[BlockStepCount][][];
            for (var i = 0; i < BlockBuffer.Length; i++)
            {
                var buffer = new double[NumChannel][];
                for (var j = 0; j < StepBuffer.Length; j++) buffer[j] = new double[StepSampleCount];
                BlockBuffer[i] = buffer;
            }

            // init short-term loudness
            _shortTermMeanSquaresLength = (int)Math.Round(ShortTermDuration / StepDuration);
            _shortTermMeanSquares = new double[_shortTermMeanSquaresLength];

            // init integrated loudness
            IsIntegrating = false;

            PreFilter = new SecondOrderIirFilter(
                1.53512485958697, // b0
                -2.69169618940638, // b1
                1.19839281085285, // b2
                -1.69065929318241, // a1
                0.73248077421585 // a2
            );
            PreFilter.Prepare(sampleRate, numChannels);

            HighPassFilter = new SecondOrderIirFilter(
                1.0, // b0
                -2.0, // b1
                1.0, // b2
                -1.99004745483398, // a1
                0.99007225036621 // a2
            );
            HighPassFilter.Prepare(sampleRate, numChannels);
        }

        /// <summary>
        ///     Start the measure of integrated loudness
        /// </summary>
        public void StartIntegrated()
        {
            ResetIntegrated();
            IsIntegrating = true;
        }

        /// <summary>
        ///     Stop the measure of integrated loudness
        /// </summary>
        public void StopIntegrated()
        {
            IsIntegrating = false;
        }

        /// <summary>
        ///     Reset the buffer for measuring integrated loudness
        /// </summary>
        private void ResetIntegrated()
        {
            _precedingMeanSquareLoudness = new List<MeanSquareLoudness>();

            _shortTermMeanSquares = new double[_shortTermMeanSquaresLength];

            StepBufferPosition = 0;
            foreach (var buffer in StepBuffer)
                for (var j = 0; j < buffer.Length; j++)
                    buffer[j] = 0;

            for (var i = 0; i < BlockBuffer.Length; i++)
            {
                var buffer = BlockBuffer[i];
                for (var j = 0; j < StepBuffer.Length; j++)
                {
                    var b = buffer[j];
                    for (var k = 0; k < b.Length; k++) b[k] = 0;
                }

                BlockBuffer[i] = buffer;
            }
        }

        /// <summary>
        ///     Process a buffer of sample data
        /// </summary>
        /// <param name="buffer">The samples need to be process</param>
        /// <param name="progressUpdated">progress</param>
        /// <returns>A array of result with the interval of 100ms</returns>
        public void ProcessBuffer(double[][] buffer, Action<double, double> progressUpdated)
        {
            // Clone the buffer
            var clone = new double[buffer.Length][];
            for (var i = 0; i < buffer.Length; i++) clone[i] = (double[])buffer[i].Clone();
            buffer = clone;

            // “K” frequency weighting
            PreFilter.ProcessBuffer(buffer);
            HighPassFilter.ProcessBuffer(buffer);

            // Init the process
            var bufferPosition = 0;
            var bufferSampleCount = buffer[0].Length;
            while (bufferPosition + (StepSampleCount - StepBufferPosition) < bufferSampleCount)
            {
                progressUpdated?.Invoke(bufferPosition, bufferSampleCount);
                // Enough to fill a step
                for (var channel = 0; channel < NumChannel; channel++)
                    Array.Copy(buffer[channel], bufferPosition, StepBuffer[channel],
                        StepBufferPosition, StepSampleCount - StepBufferPosition);
                bufferPosition += StepSampleCount - StepBufferPosition;

                // Swap buffer
                var temp = BlockBuffer[0];
                for (var i = 1; i < BlockBuffer.Length; i++) BlockBuffer[i - 1] = BlockBuffer[i];
                BlockBuffer[BlockBuffer.Length - 1] = StepBuffer;
                StepBuffer = temp;
                StepBufferPosition = 0;

                // Calc moment loudness
                double momentaryMeanSquare = 0;
                if (BlockBuffer[0] != null)
                    for (var channel = 0; channel < NumChannel; channel++)
                    {
                        double channelSquaredSum = 0;
                        for (var step = 0; step < BlockStepCount; step++)
                        {
                            var stepBuffer = BlockBuffer[step];
                            for (var sample = 0; sample < StepSampleCount; sample++)
                            {
                                var squared = Math.Pow(stepBuffer[channel][sample], 2);
                                channelSquaredSum += squared;
                            }
                        }

                        var channelMeanSquare = channelSquaredSum / (BlockStepCount * StepSampleCount);
                        var channelWeight = GetChannelWeight(channel);
                        momentaryMeanSquare += channelWeight * channelMeanSquare;
                    }
                else
                    momentaryMeanSquare = 0;

                var momentaryLoudness = -0.691 + 10 * Math.Log10(momentaryMeanSquare);
                _momentaryLoudnessUpdated?.Invoke(momentaryLoudness);

                if (_shortTermLoudnessUpdated != null)
                {
                    // Calc short-term loudness
                    ShiftBuffer(_shortTermMeanSquares);
                    _shortTermMeanSquares[_shortTermMeanSquares.Length - 1] = momentaryMeanSquare;

                    var shortTermMeanSquaresSum = _shortTermMeanSquares.Sum();
                    var shortTermMeanSquareMean = shortTermMeanSquaresSum / _shortTermMeanSquares.Length;
                    var shortTermLoudness = -0.691 + 10 * Math.Log10(shortTermMeanSquareMean);
                    _shortTermLoudnessUpdated?.Invoke(shortTermLoudness);
                }

                // Calc integrated loudness
                if (!IsIntegrating)
                    continue;
                var meanSquareLoudness = new MeanSquareLoudness
                {
                    MeanSquare = momentaryMeanSquare,
                    Loudness = momentaryLoudness
                };
                _precedingMeanSquareLoudness.Add(meanSquareLoudness);
            }

            // Process remaining samples
            var remainingLength = buffer[0].Length - bufferPosition;
            for (var channel = 0; channel < NumChannel; channel++)
                Array.Copy(buffer[channel], bufferPosition, StepBuffer[channel], StepBufferPosition, remainingLength);
            StepBufferPosition = remainingLength;
        }

        private static void ShiftBuffer(IList<double> buffer)
        {
            for (var i = 1; i < buffer.Count; i++) buffer[i - 1] = buffer[i];
        }

        private static double GetChannelWeight(int channel)
        {
            double weight = 1;
            if (channel == 3 || channel == 4) weight = 1.41;

            return weight;
        }

        private struct MeanSquareLoudness
        {
            public double MeanSquare;
            public double Loudness;
        }

        private delegate void LoudnessUpdatedHandler(double loudness);

        /// <summary>
        ///     Models of realtime result returned by ProcessBuffer
        /// </summary>
        public class Result
        {
            public double MomentaryLoudness;
            public double ShortTermLoudness;
        }
    }
}