using System;

namespace ToolAnalyzer.Lufs
{
    /// <summary>
    ///     Second order IIR filter
    /// </summary>
    public class SecondOrderIirFilter
    {
        private readonly double _b0At48K, _b1At48K, _b2At48K, _a1At48K, _a2At48K;
        private readonly double _q, _vh, _vb, _vl, _arcTanK;
        private double _b0, _b1, _b2, _a1, _a2;
        private int _numChannels;
        private double[] _z1;
        private double[] _z2;

        /// <summary>
        ///     Constructor of SecondOrderIIRFilter
        /// </summary>
        /// <param name="b0At48K"></param>
        /// <param name="b1At48K"></param>
        /// <param name="b2At48K"></param>
        /// <param name="a1At48K"></param>
        /// <param name="a2At48K"></param>
        public SecondOrderIirFilter(double b0At48K, double b1At48K, double b2At48K, double a1At48K, double a2At48K)
        {
            _b0At48K = b0At48K;
            _b1At48K = b1At48K;
            _b2At48K = b2At48K;
            _a1At48K = a1At48K;
            _a2At48K = a2At48K;
            _numChannels = 0;

            var kovQ = (2.0 - 2.0 * _a2At48K) / (_a2At48K - _a1At48K + 1.0);
            var k = Math.Sqrt((_a1At48K + _a2At48K + 1.0) / (_a2At48K - _a1At48K + 1.0));
            _q = k / kovQ;
            _arcTanK = Math.Atan(k);
            _vb = (_b0At48K - _b2At48K) / (1.0 - _a2At48K);
            _vh = (_b0At48K - _b1At48K + _b2At48K) / (_a2At48K - _a1At48K + 1.0);
            _vl = (_b0At48K + _b1At48K + _b2At48K) / (_a1At48K + _a2At48K + 1.0);
        }

        /// <summary>
        ///     Prepare for processing
        /// </summary>
        /// <param name="sampleRate">Sample rate of sample data</param>
        /// <param name="numChannels">Number of channels of sample data</param>
        public void Prepare(double sampleRate, int numChannels)
        {
            _numChannels = numChannels;
            _z1 = new double[numChannels];
            _z2 = new double[numChannels];

            const double sampleRate48K = 48000.0;
            if (Math.Abs(sampleRate - sampleRate48K) < 1)
            {
                _b0 = _b0At48K;
                _b1 = _b1At48K;
                _b2 = _b2At48K;
                _a1 = _a1At48K;
                _a2 = _a2At48K;
            }
            else
            {
                var k = Math.Tan(_arcTanK * sampleRate48K / sampleRate);
                var commonFactor = 1.0 / (1.0 + k / _q + k * k);
                _b0 = (_vh + _vb * k / _q + _vl * k * k) * commonFactor;
                _b1 = 2.0 * (_vl * k * k - _vh) * commonFactor;
                _b2 = (_vh - _vb * k / _q + _vl * k * k) * commonFactor;
                _a1 = 2.0 * (k * k - 1.0) * commonFactor;
                _a2 = (1.0 - k / _q + k * k) * commonFactor;
            }
        }

        /// <summary>
        ///     Process a buffer of samples
        /// </summary>
        /// <param name="buffer">The buffer need to be processed</param>
        public void ProcessBuffer(double[][] buffer)
        {
            var numOfChannels = Math.Min(_numChannels, buffer.Length);

            for (var channel = 0; channel < numOfChannels; channel++)
            {
                var samples = buffer[channel];

                for (var i = 0; i < buffer[channel].Length; i++)
                {
                    var inVal = samples[i];

                    var factorForB0 = inVal - _a1 * _z1[channel] - _a2 * _z2[channel];
                    var outVal = _b0 * factorForB0 + _b1 * _z1[channel] + _b2 * _z2[channel];

                    _z2[channel] = _z1[channel];
                    _z1[channel] = factorForB0;

                    samples[i] = outVal;
                }
            }
        }
    }
}