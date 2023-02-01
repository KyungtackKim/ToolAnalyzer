
namespace ToolAnalyzer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesView pointSeriesView1 = new DevExpress.XtraCharts.PointSeriesView();
            DevExpress.XtraCharts.SimpleMovingAverage simpleMovingAverage1 = new DevExpress.XtraCharts.SimpleMovingAverage();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesView pointSeriesView2 = new DevExpress.XtraCharts.PointSeriesView();
            DevExpress.XtraCharts.SimpleMovingAverage simpleMovingAverage2 = new DevExpress.XtraCharts.SimpleMovingAverage();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.bbMainFile = new DevExpress.XtraBars.BarButtonItem();
            this.bbMainRecorder = new DevExpress.XtraBars.BarButtonItem();
            this.bbMainAnalysis = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.bbPrimaryAxisY = new DevExpress.XtraBars.BarButtonItem();
            this.bbSecondaryAxisY = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.chart = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleMovingAverage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleMovingAverage2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMain,
            this.barStatus});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbMainFile,
            this.bbMainRecorder,
            this.bbMainAnalysis,
            this.bbPrimaryAxisY,
            this.bbSecondaryAxisY});
            this.barManager.MainMenu = this.barMain;
            this.barManager.MaxItemId = 5;
            this.barManager.StatusBar = this.barStatus;
            // 
            // barMain
            // 
            this.barMain.BarName = "Main menu";
            this.barMain.DockCol = 0;
            this.barMain.DockRow = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbMainFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbMainRecorder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbMainAnalysis)});
            this.barMain.OptionsBar.AllowQuickCustomization = false;
            this.barMain.OptionsBar.DrawBorder = false;
            this.barMain.OptionsBar.DrawDragBorder = false;
            this.barMain.OptionsBar.MultiLine = true;
            this.barMain.OptionsBar.UseWholeRow = true;
            this.barMain.Text = "Main menu";
            // 
            // bbMainFile
            // 
            this.bbMainFile.Caption = "File";
            this.bbMainFile.Id = 0;
            this.bbMainFile.Name = "bbMainFile";
            // 
            // bbMainRecorder
            // 
            this.bbMainRecorder.Caption = "Recorder";
            this.bbMainRecorder.Id = 1;
            this.bbMainRecorder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbMainRecorder.ImageOptions.Image")));
            this.bbMainRecorder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbMainRecorder.ImageOptions.LargeImage")));
            this.bbMainRecorder.Name = "bbMainRecorder";
            this.bbMainRecorder.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbMainRecorder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbMainAction_ItemClick);
            // 
            // bbMainAnalysis
            // 
            this.bbMainAnalysis.Caption = "Analysis";
            this.bbMainAnalysis.Id = 2;
            this.bbMainAnalysis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbMainAnalysis.ImageOptions.Image")));
            this.bbMainAnalysis.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbMainAnalysis.ImageOptions.LargeImage")));
            this.bbMainAnalysis.Name = "bbMainAnalysis";
            this.bbMainAnalysis.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbMainAnalysis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbMainAction_ItemClick);
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPrimaryAxisY),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbSecondaryAxisY)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "Status bar";
            // 
            // bbPrimaryAxisY
            // 
            this.bbPrimaryAxisY.Caption = "Magnitude";
            this.bbPrimaryAxisY.Id = 3;
            this.bbPrimaryAxisY.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbPrimaryAxisY.ImageOptions.Image")));
            this.bbPrimaryAxisY.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbPrimaryAxisY.ImageOptions.LargeImage")));
            this.bbPrimaryAxisY.Name = "bbPrimaryAxisY";
            this.bbPrimaryAxisY.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbPrimaryAxisY.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbAxisY_ItemClick);
            // 
            // bbSecondaryAxisY
            // 
            this.bbSecondaryAxisY.Caption = "Power";
            this.bbSecondaryAxisY.Id = 4;
            this.bbSecondaryAxisY.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbSeondaryAxisY.ImageOptions.Image")));
            this.bbSecondaryAxisY.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbSeondaryAxisY.ImageOptions.LargeImage")));
            this.bbSecondaryAxisY.Name = "bbSecondaryAxisY";
            this.bbSecondaryAxisY.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbSecondaryAxisY.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbAxisY_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(798, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 542);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(798, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 518);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(798, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 518);
            // 
            // chart
            // 
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.Interlaced = true;
            xyDiagram1.AxisX.InterlacedColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.MinorCount = 4;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.WholeRange.AlwaysShowZeroLevel = false;
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            secondaryAxisY1.WholeRange.AlwaysShowZeroLevel = false;
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1});
            this.chart.Diagram = xyDiagram1;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox;
            this.chart.Legend.Name = "Default Legend";
            this.chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chart.Location = new System.Drawing.Point(0, 24);
            this.chart.Name = "chart";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.Name = "Magnitude";
            simpleMovingAverage1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            simpleMovingAverage1.Name = "Magintude average";
            simpleMovingAverage1.PointsCount = 100;
            pointSeriesView1.Indicators.AddRange(new DevExpress.XtraCharts.Indicator[] {
            simpleMovingAverage1});
            pointSeriesView1.PointMarkerOptions.Size = 2;
            pointSeriesView1.Shadow.Size = 1;
            series1.View = pointSeriesView1;
            series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series2.Name = "Power";
            pointSeriesView2.AxisYName = "Secondary AxisY 1";
            simpleMovingAverage2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            simpleMovingAverage2.Name = "Power average";
            simpleMovingAverage2.PointsCount = 100;
            pointSeriesView2.Indicators.AddRange(new DevExpress.XtraCharts.Indicator[] {
            simpleMovingAverage2});
            pointSeriesView2.PointMarkerOptions.Size = 2;
            pointSeriesView2.Shadow.Size = 1;
            series2.View = pointSeriesView2;
            this.chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chart.Size = new System.Drawing.Size(798, 518);
            this.chart.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 568);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormMain.IconOptions.SvgImage")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Analyzer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(simpleMovingAverage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(simpleMovingAverage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbMainFile;
        private DevExpress.XtraBars.BarButtonItem bbMainRecorder;
        private DevExpress.XtraBars.BarButtonItem bbMainAnalysis;
        private DevExpress.XtraCharts.ChartControl chart;
        private DevExpress.XtraBars.BarButtonItem bbPrimaryAxisY;
        private DevExpress.XtraBars.BarButtonItem bbSecondaryAxisY;
    }
}

