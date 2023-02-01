using System;
using DevExpress.XtraEditors;

namespace ToolAnalyzer.Forms
{
    public partial class FormRange : XtraForm
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        private FormRange()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        public FormRange(decimal min, decimal max) : this()
        {
            tbMin.Value = min;
            tbMax.Value = max;
        }

        /// <summary>
        ///     Min whole value
        /// </summary>
        public decimal MinValue => Convert.ToDecimal(tbMin.Value);

        /// <summary>
        ///     Max whole value
        /// </summary>
        public decimal MaxValue => Convert.ToDecimal(tbMax.Value);
    }
}