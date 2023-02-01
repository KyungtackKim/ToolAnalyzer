using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;
using ToolAnalyzer.Lufs;

namespace ToolAnalyzer.Manager
{
    /// <summary>
    ///     Audio manager class
    /// </summary>
    public class AudioManager
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="device">device index</param>
        /// <param name="sample">sample rate</param>
        public AudioManager(int device, int sample = 44100)
        {
            // set wave in
            Wave = new WaveInEvent
            {
                DeviceNumber = device,
                WaveFormat = new WaveFormat(sample, 16, 1),
                BufferMilliseconds = 10
            };
            // set event
            Wave.DataAvailable += WaveOnDataAvailable;
        }

        private WaveInEvent Wave { get; set; }
        private ConcurrentQueue<byte> Raw { get; } = new ConcurrentQueue<byte>();

        /// <summary>
        ///     Wave in format
        /// </summary>
        public WaveFormat Format => Wave?.WaveFormat;

        /// <summary>
        ///     Start recording
        /// </summary>
        public void Start()
        {
            // start record
            Wave.StartRecording();
        }

        /// <summary>
        ///     Stop recording
        /// </summary>
        public void Stop()
        {
            // stop record
            Wave.StopRecording();
        }

        /// <summary>
        ///     Dispose
        /// </summary>
        public void Dispose()
        {
            // stop record
            Wave?.StopRecording();
            // wave dispose
            Wave?.Dispose();
            // clear
            Wave = null;
        }

        /// <summary>
        ///     Get raw data
        /// </summary>
        /// <returns>raw data</returns>
        public IEnumerable<byte> GetRaw()
        {
            var values = new List<byte>();
            // check empty
            while (!Raw.IsEmpty)
            {
                // try dequeue
                if (!Raw.TryDequeue(out var value))
                    // exit
                    break;
                // add value
                values.Add(value);
            }

            return values;
        }

        private void WaveOnDataAvailable(object sender, WaveInEventArgs e)
        {
            // check count
            for (var i = 0; i < e.BytesRecorded; i++)
                // enqueue raw data
                Raw.Enqueue(e.Buffer[i]);
            /*
            // get info
            var bps = Wave.WaveFormat.BitsPerSample / 8;
            var count = e.BytesRecorded / bps;
            // check count
            for (var i = 0; i < count; i++)
            {
                // get sample
                var sample = BitConverter.ToInt16(e.Buffer, i * bps);
                // add raw data
                Raw.Enqueue(sample);
            }
            */
        }

        /// <summary>
        ///     Read mono wave file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <param name="multiplier">multiplier</param>
        /// <returns>result</returns>
        public static (double[] audio, int sampleRate) ReadMono(string filePath, double multiplier = 1)
        {
            // stream
            using (var wav = new AudioFileReader(filePath))
            {
                // get sample rate
                var sampleRate = wav.WaveFormat.SampleRate;
                // get byte per sample rate
                var bytesPerSample = wav.WaveFormat.BitsPerSample / 8;
                // get sample count
                var sampleCount = (int)(wav.Length / bytesPerSample);
                // get channel count
                var channelCount = wav.WaveFormat.Channels;
                // audio buffer
                var audio = new List<double>(sampleCount);
                // data buffer
                var buffer = new float[sampleRate * channelCount];

                int samplesRead;
                // read data
                while ((samplesRead = wav.Read(buffer, 0, buffer.Length)) > 0)
                    // add range
                    audio.AddRange(buffer.Take(samplesRead).Select(x => x * multiplier));
                // result
                return (audio.ToArray(), sampleRate);
            }
        }

        /// <summary>
        ///     Read LUFS from mono wav file
        /// </summary>
        /// <param name="fileName">wav file path</param>
        /// <returns>LUFS</returns>
        public static double ReadMonoLufs(string fileName)
        {
            // read mono file
            var (audio, sample) = ReadMono(fileName);
            // new data buf
            var buf = new double[1][];
            buf[0] = new double[audio.Length];
            // copy block
            Array.Copy(audio, buf[0], audio.Length);

            // lufs meter
            var lufs = new LufsMeter();
            // prepare
            lufs.Prepare(sample, buf.Length);
            // start integration
            lufs.StartIntegrated();
            // process
            lufs.ProcessBuffer(buf, null);
            // stop integration
            lufs.StopIntegrated();

            return lufs.IntegratedLoudness;
        }

        /// <summary>
        ///     Read LUFS from mono wav file
        /// </summary>
        /// <param name="audio">audio</param>
        /// <param name="sample">sample rate</param>
        /// <returns>LUFS</returns>
        public static double ReadMonoLufs(double[] audio, int sample)
        {
            // new data buf
            var buf = new double[1][];
            buf[0] = new double[audio.Length];
            // copy block
            Array.Copy(audio, buf[0], audio.Length);

            // lufs meter
            var lufs = new LufsMeter();
            // prepare
            lufs.Prepare(sample, buf.Length);
            // start integration
            lufs.StartIntegrated();
            // process
            lufs.ProcessBuffer(buf, null);
            // stop integration
            lufs.StopIntegrated();

            return lufs.IntegratedLoudness;
        }
    }
}