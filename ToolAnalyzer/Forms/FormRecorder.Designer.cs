
namespace ToolAnalyzer.Forms
{
    partial class FormRecorder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.GroupControl gcTools;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecorder));
            DevExpress.XtraEditors.LabelControl lbBaudrate;
            DevExpress.XtraEditors.LabelControl lbPorts;
            DevExpress.XtraEditors.LabelControl lbAudio;
            DevExpress.XtraEditors.LabelControl lbWavPath;
            DevExpress.XtraEditors.LabelControl lbProgress;
            DevExpress.XtraEditors.LabelControl lbDesc;
            DevExpress.XtraEditors.LabelControl lbModel;
            DevExpress.XtraEditors.LabelControl lbSerial;
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btConnect = new DevExpress.XtraEditors.SimpleButton();
            this.imgConnect = new DevExpress.Utils.ImageCollection(this.components);
            this.tbBaudrate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tbPorts = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.gcWorking = new DevExpress.XtraEditors.GroupControl();
            this.tbSerial = new DevExpress.XtraEditors.TextEdit();
            this.tbModel = new DevExpress.XtraEditors.TextEdit();
            this.btStart = new DevExpress.XtraEditors.SimpleButton();
            this.tbWavPath = new DevExpress.XtraEditors.ButtonEdit();
            this.tbAudio = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcStatus = new DevExpress.XtraEditors.GroupControl();
            this.tbDesc = new DevExpress.XtraEditors.MemoEdit();
            this.tbProgress = new DevExpress.XtraEditors.ProgressBarControl();
            gcTools = new DevExpress.XtraEditors.GroupControl();
            lbBaudrate = new DevExpress.XtraEditors.LabelControl();
            lbPorts = new DevExpress.XtraEditors.LabelControl();
            lbAudio = new DevExpress.XtraEditors.LabelControl();
            lbWavPath = new DevExpress.XtraEditors.LabelControl();
            lbProgress = new DevExpress.XtraEditors.LabelControl();
            lbDesc = new DevExpress.XtraEditors.LabelControl();
            lbModel = new DevExpress.XtraEditors.LabelControl();
            lbSerial = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(gcTools)).BeginInit();
            gcTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBaudrate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPorts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWorking)).BeginInit();
            this.gcWorking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWavPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStatus)).BeginInit();
            this.gcStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTools
            // 
            gcTools.Controls.Add(this.btConnect);
            gcTools.Controls.Add(this.tbBaudrate);
            gcTools.Controls.Add(lbBaudrate);
            gcTools.Controls.Add(this.tbPorts);
            gcTools.Controls.Add(lbPorts);
            gcTools.Location = new System.Drawing.Point(12, 12);
            gcTools.Name = "gcTools";
            gcTools.Padding = new System.Windows.Forms.Padding(10);
            gcTools.Size = new System.Drawing.Size(180, 190);
            gcTools.TabIndex = 0;
            gcTools.Text = "Tool connection";
            // 
            // btConnect
            // 
            this.btConnect.ImageOptions.ImageIndex = 0;
            this.btConnect.ImageOptions.ImageList = this.imgConnect;
            this.btConnect.Location = new System.Drawing.Point(15, 145);
            this.btConnect.Name = "btConnect";
            this.btConnect.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btConnect.Size = new System.Drawing.Size(150, 25);
            this.btConnect.TabIndex = 4;
            this.btConnect.Text = "Connect";
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // imgConnect
            // 
            this.imgConnect.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgConnect.ImageStream")));
            this.imgConnect.Images.SetKeyName(0, "add_16x16.png");
            this.imgConnect.Images.SetKeyName(1, "remove_16x16.png");
            this.imgConnect.Images.SetKeyName(2, "play_16x16.png");
            this.imgConnect.Images.SetKeyName(3, "stop_16x16.png");
            // 
            // tbBaudrate
            // 
            this.tbBaudrate.EditValue = "115200";
            this.tbBaudrate.Location = new System.Drawing.Point(15, 110);
            this.tbBaudrate.Name = "tbBaudrate";
            this.tbBaudrate.Properties.AllowFocused = false;
            this.tbBaudrate.Properties.Appearance.Options.UseTextOptions = true;
            this.tbBaudrate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbBaudrate.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.tbBaudrate.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbBaudrate.Properties.AutoHeight = false;
            this.tbBaudrate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbBaudrate.Properties.DropDownItemHeight = 25;
            this.tbBaudrate.Properties.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "19200",
            "9600"});
            this.tbBaudrate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tbBaudrate.Size = new System.Drawing.Size(150, 25);
            this.tbBaudrate.TabIndex = 3;
            // 
            // lbBaudrate
            // 
            lbBaudrate.Location = new System.Drawing.Point(15, 90);
            lbBaudrate.Name = "lbBaudrate";
            lbBaudrate.Size = new System.Drawing.Size(49, 14);
            lbBaudrate.TabIndex = 2;
            lbBaudrate.Text = "Baudrate";
            // 
            // tbPorts
            // 
            this.tbPorts.Location = new System.Drawing.Point(15, 56);
            this.tbPorts.Name = "tbPorts";
            this.tbPorts.Properties.AllowFocused = false;
            this.tbPorts.Properties.Appearance.Options.UseTextOptions = true;
            this.tbPorts.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbPorts.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.tbPorts.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbPorts.Properties.AutoHeight = false;
            this.tbPorts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbPorts.Properties.DropDownItemHeight = 25;
            this.tbPorts.Properties.Sorted = true;
            this.tbPorts.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tbPorts.Size = new System.Drawing.Size(150, 25);
            this.tbPorts.TabIndex = 1;
            // 
            // lbPorts
            // 
            lbPorts.Location = new System.Drawing.Point(15, 36);
            lbPorts.Name = "lbPorts";
            lbPorts.Size = new System.Drawing.Size(28, 14);
            lbPorts.TabIndex = 0;
            lbPorts.Text = "Ports";
            // 
            // lbAudio
            // 
            lbAudio.Location = new System.Drawing.Point(15, 36);
            lbAudio.Name = "lbAudio";
            lbAudio.Size = new System.Drawing.Size(75, 14);
            lbAudio.TabIndex = 2;
            lbAudio.Text = "Audio devices";
            // 
            // lbWavPath
            // 
            lbWavPath.Location = new System.Drawing.Point(15, 90);
            lbWavPath.Name = "lbWavPath";
            lbWavPath.Size = new System.Drawing.Size(79, 14);
            lbWavPath.TabIndex = 28;
            lbWavPath.Text = "Wave file path";
            // 
            // lbProgress
            // 
            lbProgress.Location = new System.Drawing.Point(15, 36);
            lbProgress.Name = "lbProgress";
            lbProgress.Size = new System.Drawing.Size(46, 14);
            lbProgress.TabIndex = 3;
            lbProgress.Text = "Progress";
            // 
            // lbDesc
            // 
            lbDesc.Location = new System.Drawing.Point(15, 96);
            lbDesc.Name = "lbDesc";
            lbDesc.Size = new System.Drawing.Size(60, 14);
            lbDesc.TabIndex = 5;
            lbDesc.Text = "Description";
            // 
            // lbModel
            // 
            lbModel.Location = new System.Drawing.Point(373, 36);
            lbModel.Name = "lbModel";
            lbModel.Size = new System.Drawing.Size(66, 14);
            lbModel.TabIndex = 31;
            lbModel.Text = "Model name";
            // 
            // lbSerial
            // 
            lbSerial.Location = new System.Drawing.Point(373, 90);
            lbSerial.Name = "lbSerial";
            lbSerial.Size = new System.Drawing.Size(74, 14);
            lbSerial.TabIndex = 33;
            lbSerial.Text = "Serial number";
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // gcWorking
            // 
            this.gcWorking.Controls.Add(lbSerial);
            this.gcWorking.Controls.Add(this.tbSerial);
            this.gcWorking.Controls.Add(lbModel);
            this.gcWorking.Controls.Add(this.tbModel);
            this.gcWorking.Controls.Add(this.btStart);
            this.gcWorking.Controls.Add(lbWavPath);
            this.gcWorking.Controls.Add(this.tbWavPath);
            this.gcWorking.Controls.Add(this.tbAudio);
            this.gcWorking.Controls.Add(lbAudio);
            this.gcWorking.Location = new System.Drawing.Point(198, 12);
            this.gcWorking.Name = "gcWorking";
            this.gcWorking.Padding = new System.Windows.Forms.Padding(10);
            this.gcWorking.Size = new System.Drawing.Size(588, 190);
            this.gcWorking.TabIndex = 1;
            this.gcWorking.Text = "Working options";
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(373, 110);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Properties.Appearance.Options.UseTextOptions = true;
            this.tbSerial.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbSerial.Properties.AutoHeight = false;
            this.tbSerial.Properties.MaxLength = 32;
            this.tbSerial.Size = new System.Drawing.Size(200, 25);
            this.tbSerial.TabIndex = 32;
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(373, 56);
            this.tbModel.Name = "tbModel";
            this.tbModel.Properties.Appearance.Options.UseTextOptions = true;
            this.tbModel.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbModel.Properties.AutoHeight = false;
            this.tbModel.Properties.MaxLength = 32;
            this.tbModel.Size = new System.Drawing.Size(200, 25);
            this.tbModel.TabIndex = 30;
            // 
            // btStart
            // 
            this.btStart.ImageOptions.ImageIndex = 2;
            this.btStart.ImageOptions.ImageList = this.imgConnect;
            this.btStart.Location = new System.Drawing.Point(423, 145);
            this.btStart.Name = "btStart";
            this.btStart.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btStart.Size = new System.Drawing.Size(150, 25);
            this.btStart.TabIndex = 29;
            this.btStart.Text = "Start";
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbWavPath
            // 
            this.tbWavPath.Location = new System.Drawing.Point(15, 110);
            this.tbWavPath.Name = "tbWavPath";
            this.tbWavPath.Properties.AllowFocused = false;
            this.tbWavPath.Properties.AutoHeight = false;
            this.tbWavPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", 20, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.tbWavPath.Properties.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.tbWavPath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tbWavPath.Size = new System.Drawing.Size(352, 25);
            this.tbWavPath.TabIndex = 27;
            this.tbWavPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.tbWavPath_ButtonClick);
            // 
            // tbAudio
            // 
            this.tbAudio.Location = new System.Drawing.Point(15, 56);
            this.tbAudio.Name = "tbAudio";
            this.tbAudio.Properties.AllowFocused = false;
            this.tbAudio.Properties.Appearance.Options.UseTextOptions = true;
            this.tbAudio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbAudio.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.tbAudio.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbAudio.Properties.AutoHeight = false;
            this.tbAudio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbAudio.Properties.DropDownItemHeight = 25;
            this.tbAudio.Properties.Sorted = true;
            this.tbAudio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tbAudio.Size = new System.Drawing.Size(352, 25);
            this.tbAudio.TabIndex = 3;
            // 
            // gcStatus
            // 
            this.gcStatus.Controls.Add(lbDesc);
            this.gcStatus.Controls.Add(this.tbDesc);
            this.gcStatus.Controls.Add(lbProgress);
            this.gcStatus.Controls.Add(this.tbProgress);
            this.gcStatus.Location = new System.Drawing.Point(12, 208);
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.Padding = new System.Windows.Forms.Padding(10);
            this.gcStatus.Size = new System.Drawing.Size(774, 348);
            this.gcStatus.TabIndex = 2;
            this.gcStatus.Text = "Working status";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(15, 116);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.tbDesc.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.tbDesc.Properties.ReadOnly = true;
            this.tbDesc.Size = new System.Drawing.Size(744, 232);
            this.tbDesc.TabIndex = 4;
            // 
            // tbProgress
            // 
            this.tbProgress.Location = new System.Drawing.Point(15, 56);
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Properties.AllowFocused = false;
            this.tbProgress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tbProgress.Properties.ReadOnly = true;
            this.tbProgress.Properties.ShowTitle = true;
            this.tbProgress.Size = new System.Drawing.Size(744, 25);
            this.tbProgress.TabIndex = 0;
            // 
            // FormRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 568);
            this.Controls.Add(this.gcStatus);
            this.Controls.Add(this.gcWorking);
            this.Controls.Add(gcTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormRecorder.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRecorder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRecorder";
            this.Load += new System.EventHandler(this.FormRecorder_Load);
            ((System.ComponentModel.ISupportInitialize)(gcTools)).EndInit();
            gcTools.ResumeLayout(false);
            gcTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBaudrate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPorts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcWorking)).EndInit();
            this.gcWorking.ResumeLayout(false);
            this.gcWorking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbWavPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAudio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStatus)).EndInit();
            this.gcStatus.ResumeLayout(false);
            this.gcStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit tbPorts;
        private DevExpress.XtraEditors.ComboBoxEdit tbBaudrate;
        private DevExpress.XtraEditors.SimpleButton btConnect;
        private DevExpress.Utils.ImageCollection imgConnect;
        private System.ComponentModel.BackgroundWorker Worker;
        private DevExpress.XtraEditors.GroupControl gcWorking;
        private DevExpress.XtraEditors.ComboBoxEdit tbAudio;
        private DevExpress.XtraEditors.ButtonEdit tbWavPath;
        private DevExpress.XtraEditors.SimpleButton btStart;
        private DevExpress.XtraEditors.GroupControl gcStatus;
        private DevExpress.XtraEditors.ProgressBarControl tbProgress;
        private DevExpress.XtraEditors.MemoEdit tbDesc;
        private DevExpress.XtraEditors.TextEdit tbModel;
        private DevExpress.XtraEditors.TextEdit tbSerial;
    }
}