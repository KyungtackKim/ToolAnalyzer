using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using HComm.Common;
using HComm.Device;
using NAudio.Wave;
using ToolAnalyzer.Manager;

namespace ToolAnalyzer.Forms
{
    public partial class FormRecorder : XtraForm
    {
        public FormRecorder()
        {
            InitializeComponent();
        }

        private HComm.HComm Comm { get; } = new HComm.HComm();
        private AudioManager Audio { get; set; }
        private WorkerManager WorkState { get; set; }
        private StringBuilder Log { get; } = new StringBuilder();
        private bool IsStop { get; set; }
        private ushort MinTorque { get; set; }
        private ushort MaxTorque { get; set; }
        private int Percent { get; set; }

        private void FormRecorder_Load(object sender, EventArgs e)
        {
            // get port list
            tbPorts.Properties.Items.AddRange(HcSerial.GetPortNames().ToList());
            // check count
            if (tbPorts.Properties.Items.Count > 0)
                // select first
                tbPorts.SelectedIndex = 0;
            // check device count
            for (var i = 0; i < WaveIn.DeviceCount; i++)
                // add device
                tbAudio.Properties.Items.Add(WaveIn.GetCapabilities(i).ProductName);
            // check count
            if (tbAudio.Properties.Items.Count > 0)
                // select first
                tbAudio.SelectedIndex = 0;

            // set save path
            tbWavPath.Text = ConfigManager.SavePath;

            // set event
            Comm.ChangedConnection += state =>
            {
                // request min / max torque
                while (!Comm.GetParam(1002, 1))
                {
                }

                while (!Comm.GetParam(2002, 1))
                {
                }

                // update button
                btConnect.Invoke(new EventHandler(delegate
                {
                    btConnect.Text = state ? @"Disconnect" : @"Connect";
                    btConnect.ImageIndex = state ? 1 : 0;
                }));
            };
            Comm.ReceivedMsg += ReceivedMsg;
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            // try catch
            try
            {
                // check button
                switch (Comm.State)
                {
                    case ConnectionState.Disconnected when btConnect.Text == @"Connect":
                        // get options
                        var port = $@"{tbPorts.SelectedItem}";
                        var baud = Convert.ToInt32(tbBaudrate.SelectedItem);
                        // check options
                        if (string.IsNullOrWhiteSpace(port))
                            break;
                        // setup
                        Comm.SetUp(CommType.Serial);
                        // try connect
                        if (!Comm.Connect(port, baud))
                            // error
                            XtraMessageBox.Show(@"Failed to connect");
                        // change state
                        tbPorts.Enabled = false;
                        tbBaudrate.Enabled = false;
                        break;
                    default:
                        // check connection state
                        if (Comm.State == ConnectionState.Connected)
                            // close
                            Comm.Close();
                        // change state
                        tbPorts.Enabled = true;
                        tbBaudrate.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                // debug
                Debug.WriteLine(ex.Message);
            }
        }

        private void tbWavPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            // dialog
            using (var dlg = new XtraFolderBrowserDialog())
            {
                // set options
                dlg.StartPosition = FormStartPosition.CenterScreen;
                // show dialog
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                // set text
                tbWavPath.Text = dlg.SelectedPath;
                // set config
                ConfigManager.SavePath = dlg.SelectedPath;
                // save config
                ConfigManager.Save();
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            // check state
            switch (btStart.Text)
            {
                case @"Start":
                    // check audio index
                    if (tbAudio.SelectedIndex < 0)
                        return;
                    // check work state
                    if (WorkState == null)
                        // create work state
                        WorkState = new WorkerManager(MinTorque, MaxTorque);
                    // check audio
                    if (Audio == null)
                        // create audio
                        Audio = new AudioManager(tbAudio.SelectedIndex);
                    // clear log
                    Log.Clear();
                    // set log
                    WriteLog($@"START PROCESS [{tbModel.Text.Trim()}-{tbSerial.Text.Trim()}]");
                    // start record
                    Audio.Start();
                    // start worker
                    Worker.RunWorkerAsync();
                    // change caption
                    btStart.Text = @"Stop";
                    tbAudio.Enabled = false;
                    tbWavPath.Enabled = false;
                    tbModel.Enabled = false;
                    tbSerial.Enabled = false;
                    break;
                case @"Stop":
                    // stop worker
                    IsStop = true;
                    // stop tool
                    Comm.SetParam(4003, 0);
                    // stop record
                    Audio.Stop();
                    // dispose audio
                    Audio?.Dispose();
                    Audio = null;
                    // dispose work state
                    WorkState = null;
                    // change caption
                    btStart.Text = @"Start";
                    tbAudio.Enabled = true;
                    tbWavPath.Enabled = true;
                    tbModel.Enabled = true;
                    tbSerial.Enabled = true;
                    // set log
                    WriteLog(@"STOP PROCESS");
                    break;
            }
        }

        private void ReceivedMsg(Command cmd, int addr, int[] values)
        {
            // check command
            switch (cmd)
            {
                case Command.None:
                    break;
                case Command.Read:
                    // check address
                    switch (addr)
                    {
                        case 8:
                            // check worker state
                            if (WorkState != null)
                                // set speed
                                WorkState.Speed = (ushort)values[0];
                            // log
                            WriteLog($@"CURRENT SPEED: {WorkState?.Speed}");
                            break;
                        case 1002:
                            // set min torque
                            MinTorque = (ushort)values[0];
                            break;
                        case 2002:
                            // set max torque
                            MaxTorque = (ushort)values[0];
                            break;
                    }

                    break;
                case Command.Mor:
                    // check address
                    if (addr == 3300 && WorkState != null)
                    {
                        // set temperature
                        WorkState.Temp = (ushort)values[13];
                        // log
                        WriteLog($@"CURRENT TEMPERATURE: {WorkState.Temp / 10.0:F1}");
                    }

                    break;
                case Command.Write:
                    // check address
                    if (addr == 2 && WorkState != null)
                        // log
                        WriteLog($@"CURRENT TORQUE: {WorkState.Torque / 100.0:F2}");

                    break;
                case Command.Info:
                    break;
                case Command.Graph:
                    break;
                case Command.GraphRes:
                    break;
                case Command.GraphAd:
                    break;
                case Command.Error:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cmd), cmd, null);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // get worker
            if (!(sender is BackgroundWorker worker))
                return;
            // check connection state
            if (Comm.State != ConnectionState.Connected)
                return;
            // change state
            WorkState.ChangeState(WorkerManager.WorkingState.Offset);
            // get folder path
            var folder = Path.Combine(tbWavPath.Text, tbModel.Text.Trim(), tbSerial.Text.Trim(),
                $@"{DateTime.Now:yyyyMMdd}");
            // check exists
            if (!Directory.Exists(folder))
                // create folder
                Directory.CreateDirectory(folder);
            // loop
            while (true)
            {
                // check stop
                if (IsStop)
                    break;

                // get values
                var values = Audio.GetRaw();

                // get percent
                var percent = Convert.ToInt32((double)WorkState.Torque / WorkState.MaxTorque * 100.0);
                // check percent
                if (Percent != percent)
                {
                    // report progress
                    worker.ReportProgress(percent);
                    // set percent
                    Percent = percent;
                }

                string name;
                DateTime time;
                // check work state
                switch (WorkState.State)
                {
                    case WorkerManager.WorkingState.Offset:
                        // check time laps
                        if (WorkState.GetLaps() < WorkerManager.OffsetDelay)
                            break;
                        // recording offset
                        WorkState.Values.AddRange(values);
                        // check time laps
                        if (WorkState.GetLaps() < WorkerManager.RecordTime)
                            break;

                        // check exists
                        if (!Directory.Exists(folder))
                            // create folder
                            Directory.CreateDirectory(folder);

                        // get time
                        time = DateTime.Now;
                        // get file name
                        name = Path.Combine(folder, $@"{time:HHmmss}_0.wav");
                        // stream
                        using (var stream = new FileStream(name, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            // wave writer
                            using (var wave = new WaveFileWriter(stream, Audio.Format))
                            {
                                // write
                                wave.Write(WorkState.Values.ToArray(), 0, WorkState.Values.Count);
                                // log
                                WriteLog($@"SAVED WAV FILE: {time:HHmmss}_0.wav");
                            }
                        }

                        // log
                        WriteLog(@"STOP OFFSET");
                        // change state
                        WorkState.ChangeState(WorkerManager.WorkingState.Stop);

                        break;
                    case WorkerManager.WorkingState.Stop:
                        // check time laps
                        if (WorkState.GetLaps() < WorkerManager.StopDelay)
                            break;
                        // clear values
                        WorkState.Values.Clear();
                        // log
                        WriteLog(@"=========================", false);
                        // check next record
                        if (WorkState.NextRecord())
                            // change state
                            WorkState.ChangeState(WorkerManager.WorkingState.DriverPreDelay);
                        else
                            // invoke
                            btStart.Invoke(new EventHandler(delegate
                            {
                                // try stop
                                btStart.PerformClick();
                            }));

                        break;
                    case WorkerManager.WorkingState.DriverPreDelay:
                        // check time laps
                        if (WorkState.GetLaps() < WorkerManager.DrvDelay)
                            break;
                        // set torque
                        while (!Comm.SetParam(2, WorkState.Torque))
                        {
                        }

                        // get speed
                        while (!Comm.GetParam(8, 1))
                        {
                        }

                        // run driver
                        while (!Comm.SetParam(4003, 1))
                        {
                        }

                        // change state
                        WorkState.ChangeState(WorkerManager.WorkingState.RecordPreDelay);
                        break;
                    case WorkerManager.WorkingState.RecordPreDelay:
                        // check time laps
                        if (WorkState.GetLaps() < WorkerManager.RecDelay)
                            break;
                        // change state
                        WorkState.ChangeState(WorkerManager.WorkingState.Record);
                        // log
                        WriteLog(@"START RECORD");
                        break;
                    case WorkerManager.WorkingState.Record:
                        // recording
                        WorkState.Values.AddRange(values);
                        // check time laps
                        if (WorkState.GetLaps() < WorkerManager.RecordTime)
                            break;
                        // change state
                        WorkState.ChangeState(WorkerManager.WorkingState.DriverAfterDelay);
                        // log
                        WriteLog(@"STOP RECORD");
                        break;
                    case WorkerManager.WorkingState.DriverAfterDelay:
                        // check time laps
                        if (WorkState.GetLaps() < WorkerManager.DrvDelay)
                            break;
                        // get state
                        while (!Comm.GetState())
                        {
                        }

                        // stop driver
                        while (!Comm.SetParam(4003, 0))
                        {
                        }

                        // change state
                        WorkState.ChangeState(WorkerManager.WorkingState.RecordAfterDelay);
                        break;
                    case WorkerManager.WorkingState.RecordAfterDelay:
                        // check time laps
                        if (WorkState.GetLaps() < WorkerManager.RecDelay)
                            break;

                        // get time
                        time = DateTime.Now;
                        // get file name
                        name = Path.Combine(folder, $@"{time:HHmmss}_{WorkState.Torque}.wav");
                        // stream
                        using (var stream = new FileStream(name, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            // wave writer
                            using (var wave = new WaveFileWriter(stream, Audio.Format))
                            {
                                // write
                                wave.Write(WorkState.Values.ToArray(), 0, WorkState.Values.Count);
                                // log
                                WriteLog($@"SAVED WAV FILE: {time:HHmmss}_{WorkState.Torque}.wav");
                            }
                        }

                        // check file exists
                        if (File.Exists(name))
                            // loudness log
                            WriteLog($@"LOUDNESS: {AudioManager.ReadMonoLufs(name):F2} LUFS");

                        // change state
                        WorkState.ChangeState(WorkerManager.WorkingState.Stop);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // reset state
            IsStop = false;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // set value
            tbProgress.Position = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void WriteLog(string log, bool time = true)
        {
            // check time
            if (time)
                // append time
                Log.Append($@"[{DateTime.Now:HH:mm:ss}] ");
            // add log
            Log.AppendLine(log);
            // update log
            tbDesc.Invoke(new EventHandler(delegate
            {
                // set log
                tbDesc.Text = $@"{Log}";
                // scroll
                tbDesc.SelectionStart = tbDesc.Text.Length;
                tbDesc.ScrollToCaret();
            }));
        }
    }
}