using System;
using System.Windows.Forms;

namespace Pk3DSRNGTool.Controls
{
    public class HexMaskedTextBox : MaskedTextBox
    {
        public HexMaskedTextBox()
        {
            Mask = "AAAAAAAA";
            Size = new System.Drawing.Size(66, 22);
        }

        public uint Value
        {
            get => uint.TryParse(Text, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out uint value) ? value : 0;
            set => Text = value.ToString("X8");
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
                if (Mask[SelectionStart].Equals('A'))
                {
                    if (e.KeyChar != (char)Keys.Back && !char.IsControl(e.KeyChar))
                    {
                        if ((e.KeyChar >= 'a') && (e.KeyChar <= 'f'))
                        {
                            e.KeyChar = char.ToUpper(e.KeyChar);
                        }
                        else if (((e.KeyChar >= 'A') && (e.KeyChar <= 'F')) ||
                                 ((e.KeyChar >= '0') && (e.KeyChar <= '9')))
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
                if (Mask[charPos].Equals('A'))
                {
                    if (((Text[charPos] >= 'a') && (Text[charPos] <= 'f')) ||
                        ((Text[charPos] >= 'A') && (Text[charPos] <= 'F')) ||
                        ((Text[charPos] >= '0') && (Text[charPos] <= '9')))
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