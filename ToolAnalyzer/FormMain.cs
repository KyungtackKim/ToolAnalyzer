using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using FftSharp;
using FftSharp.Windows;
using Spectrogram;
using ToolAnalyzer.Forms;
using ToolAnalyzer.Manager;

namespace ToolAnalyzer
{
    public partial class FormMain : XtraForm
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        private void bbMainAction_ItemClick(object sender, ItemClickEventArgs e)
        {
            // form
            XtraForm form = null;
            // check sender
            switch (e.Item.Name)
            {
                case @"bbMainRecorder":
                    // recorder
                    form = new FormRecorder();
                    // show dialog
                    form.ShowDialog();

                    break;
                case @"bbMainAnalysis":
                    // open dialog
                    using (var dlg = new XtraOpenFileDialog())
                    {
                        // set options
                        dlg.StartPosition = FormStartPosition.CenterScreen;
                        dlg.Filter = @"PCM Files (*.wav)|*.wav";
                        // show dialog
                        if (dlg.ShowDialog() != DialogResult.OK)
                            return;
                        // get file path
                        var fileName = dlg.FileName;
                        var path = Path.GetDirectoryName(fileName);
                        var name = dlg.SafeFileName.Split('.').First();

                        // read wav file
                        var (audio, sample) = AudioManager.ReadMono(fileName);

                        // spectrogram
                        var sg = new SpectrogramGenerator(sample, 2048, 512,
                            WorkerManager.MinFreq, WorkerManager.MaxFreq);
                        // add values
                        sg.Add(audio);
                        // check path
                        if (path != null)
                            // save image
                            sg.SaveImage(Path.Combine(path, $@"his_{name}.png"), 2500, true);

                        /*  FFT  */
                        // window
                        var window = new Hanning();
                        // apply window
                        window.ApplyInPlace(audio);
                        // set zero pad
                        var zValue = Pad.ZeroPad(audio);
                        // set filter
                        var value = Filter.BandPass(zValue, sample, WorkerManager.MinFreq, WorkerManager.MaxFreq);
                        // set magnitude
                        var mValue = Transform.FFTmagnitude(value);
                        // set power
                        var pValue = Transform.FFTpower(value);
                        // set frequency
                        var fValue = Transform.FFTfreq(sample, mValue.Length);
                        /**/

                        // begin point
                        chart.BeginInit();
                        // clear
                        chart.Series[0].Points.Clear();
                        chart.Series[1].Points.Clear();

                        /* Amplitude *
                        // check length
                        for (var i = 0; i < audio.Length; i++)
                            // add
                            chart.Series[0].Points.AddPoint(i, audio[i]);
                        // debug
                        // Debug.WriteLine(name);
                        // Debug.WriteLine($@"{audio.Max():F6}");
                        // Debug.WriteLine($@"{audio.Min():F6}");
                        // Debug.WriteLine($@"{audio.Sum() / audio.Length:F12}");
                        **/

                        /*  Magnitude and Power */
                        // check length
                        for (var i = 0; i < fValue.Length; i++)
                        {
                            // get frequency
                            var freq = fValue[i];
                            // check filter
                            if (freq < WorkerManager.MinFreq || freq > WorkerManager.MaxFreq)
                                continue;
                            // add
                            chart.Series[0].Points.AddPoint(freq, mValue[i]);
                            chart.Series[1].Points.AddPoint(freq, pValue[i]);
                        }

                        // get diagram
                        var diagram = (XYDiagram)chart.Diagram;
                        // set axis
                        diagram.AxisY.WholeRange.Auto = false;
                        diagram.AxisY.WholeRange.SetMinMaxValues(0, 0.005);
                        diagram.SecondaryAxesY[0].WholeRange.Auto = false;
                        diagram.SecondaryAxesY[0].WholeRange.SetMinMaxValues(-200, 0);

                        // end point
                        chart.EndInit();

                        // check path
                        if (path != null)
                            // save chart image
                            chart.ExportToImage(Path.Combine(path, $@"fft_{name}.png"), ImageFormat.Png);
                    }

                    break;
            }

            // dispose
            form?.Dispose();
        }

        private void bbAxisY_ItemClick(object sender, ItemClickEventArgs e)
        {
            // get diagram
            var diagram = (XYDiagram)chart.Diagram;
            // check item
            switch (e.Item.Name)
            {
                case @"bbPrimaryAxisY":
                    // dialog
                    using (var dlg = new FormRange(Convert.ToDecimal(diagram.AxisY.WholeRange.MinValue),
                               Convert.ToDecimal(diagram.AxisY.WholeRange.MaxValue)))
                    {
                        // show dialog
                        if (dlg.ShowDialog() != DialogResult.OK)
                            return;
                        // set whole range
                        diagram.AxisY.WholeRange.SetMinMaxValues(dlg.MinValue, dlg.MaxValue);
                    }

                    break;
                case @"bbSecondaryAxisY":
                    // dialog
                    using (var dlg = new FormRange(Convert.ToDecimal(diagram.SecondaryAxesY[0].WholeRange.MinValue),
                               Convert.ToDecimal(diagram.SecondaryAxesY[0].WholeRange.MaxValue)))
                    {
                        // show dialog
                        if (dlg.ShowDialog() != DialogResult.OK)
                            return;
                        // set whole range
                        diagram.SecondaryAxesY[0].WholeRange.SetMinMaxValues(dlg.MinValue, dlg.MaxValue);
                    }

                    break;
            }
        }
    }
}