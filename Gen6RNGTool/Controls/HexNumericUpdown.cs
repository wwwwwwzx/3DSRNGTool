using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SMEncounterRNGTool.Controls
{

    public class HexNumericUpdown : NumericUpDown
    {
        public HexNumericUpdown()
        {
            base.Hexadecimal = true;
            base.Minimum = 0;
            base.Maximum = uint.MaxValue;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public new decimal Maximum
        {    // Doesn't serialize properly 
            get { return base.Maximum; }
            set { base.Maximum = value; }
        }

        protected override void UpdateEditText()
        {
            if (base.UserEdit) HexParseEditText();
            if (!string.IsNullOrEmpty(base.Text))
            {
                base.ChangingText = true;
                base.Text = string.Format("{0:X}", (uint)base.Value);
            }
        }

        protected override void ValidateEditText()
        {
            HexParseEditText();
            UpdateEditText();
        }

        private void HexParseEditText()
        {
            try
            {
                if (!string.IsNullOrEmpty(base.Text))
                    this.Value = Convert.ToInt64(base.Text, 16);
            }
            catch { }
            finally
            {
                base.UserEdit = false;
            }
        }
    }
}
