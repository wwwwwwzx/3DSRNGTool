using System;
using System.Windows.Forms;

namespace Pk3DSRNGTool.Controls
{
    public class GenderListBox : MaskedTextBox
    {
        public GenderListBox()
        {
            Mask = "00000000000000000000";
            TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            Focus();
            SelectAll();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (SelectionStart > Text.Length)
                SelectionStart = Text.Length;

            if (e.KeyChar == ' ') e.KeyChar = (char)0;

            if (SelectionStart < Mask.Length)
            {
                if (Mask[SelectionStart].Equals('0'))
                {
                    if (e.KeyChar != (char)Keys.Back && !char.IsControl(e.KeyChar))
                    {
                        if ((e.KeyChar >= '0') && (e.KeyChar <= '2'))
                        {
                        }
                        else
                            e.KeyChar = (char)0;
                    }
                }
            }
            base.OnKeyPress(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            string replace = "";
            for (int charPos = 0; charPos < Text.Length; charPos++)
            {
                if (Mask[charPos].Equals('0'))
                {
                    if (((Text[charPos] >= '0') && (Text[charPos] <= '2')))
                    {
                        replace = replace + Text[charPos];
                    }
                }
            }
            Text = replace;

            base.OnTextChanged(e);
        }
    }
}