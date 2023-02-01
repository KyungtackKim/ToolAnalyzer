
namespace ToolAnalyzer.Forms
{
    partial class FormRange
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
            DevExpress.XtraEditors.LabelControl lbMin;
            DevExpress.XtraEditors.LabelControl lbMax;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRange));
            this.tbMin = new DevExpress.XtraEditors.SpinEdit();
            this.tbMax = new DevExpress.XtraEditors.SpinEdit();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            lbMin = new DevExpress.XtraEditors.LabelControl();
            lbMax = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tbMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMax.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMin
            // 
            lbMin.Location = new System.Drawing.Point(23, 28);
            lbMin.Name = "lbMin";
            lbMin.Size = new System.Drawing.Size(50, 14);
            lbMin.TabIndex = 0;
            lbMin.Text = "Min value";
            // 
            // tbMin
            // 
            this.tbMin.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbMin.Location = new System.Drawing.Point(105, 23);
            this.tbMin.Name = "tbMin";
            this.tbMin.Properties.Appearance.Options.UseTextOptions = true;
            this.tbMin.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbMin.Properties.AutoHeight = false;
            this.tbMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbMin.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbMin.Properties.MinValue = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.tbMin.Size = new System.Drawing.Size(170, 25);
            this.tbMin.TabIndex = 1;
            // 
            // tbMax
            // 
            this.tbMax.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbMax.Location = new System.Drawing.Point(105, 54);
            this.tbMax.Name = "tbMax";
            this.tbMax.Properties.Appearance.Options.UseTextOptions = true;
            this.tbMax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbMax.Properties.AutoHeight = false;
            this.tbMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tbMax.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.tbMax.Properties.MinValue = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.tbMax.Size = new System.Drawing.Size(170, 25);
            this.tbMax.TabIndex = 3;
            // 
            // lbMax
            // 
            lbMax.Location = new System.Drawing.Point(23, 59);
            lbMax.Name = "lbMax";
            lbMax.Size = new System.Drawing.Size(53, 14);
            lbMax.TabIndex = 2;
            lbMax.Text = "Max value";
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btOk.ImageOptions.SvgImage")));
            this.btOk.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btOk.Location = new System.Drawing.Point(23, 111);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(110, 25);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "OK";
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.simpleButton1.Location = new System.Drawing.Point(165, 111);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(110, 25);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "CANCEL";
            // 
            // FormRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 157);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.tbMax);
            this.Controls.Add(lbMax);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(lbMin);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormRange.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRange";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Whole range";
            ((System.ComponentModel.ISupportInitialize)(this.tbMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMax.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit tbMin;
        private DevExpress.XtraEditors.SpinEdit tbMax;
        private DevExpress.XtraEditors.SimpleButton btOk;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}