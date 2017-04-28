using System.Collections.Generic;
using System.Windows.Forms;

namespace pkm3dsRNG
{
    public partial class MainForm : Form
    {
        private int[] IVup
        {
            get { return new[] { (int)ivmax0.Value, (int)ivmax1.Value, (int)ivmax2.Value, (int)ivmax3.Value, (int)ivmax4.Value, (int)ivmax5.Value, }; }
            set
            {
                if (value.Length < 6) return;
                ivmax0.Value = value[0]; ivmax1.Value = value[1]; ivmax2.Value = value[2];
                ivmax3.Value = value[3]; ivmax4.Value = value[4]; ivmax5.Value = value[5];
            }
        }
        private int[] IVlow
        {
            get { return new[] { (int)ivmin0.Value, (int)ivmin1.Value, (int)ivmin2.Value, (int)ivmin3.Value, (int)ivmin4.Value, (int)ivmin5.Value, }; }
            set
            {
                if (value.Length < 6) return;
                ivmin0.Value = value[0]; ivmin1.Value = value[1]; ivmin2.Value = value[2];
                ivmin3.Value = value[3]; ivmin4.Value = value[4]; ivmin5.Value = value[5];
            }
        }
        private int[] BS
        {
            get { return new[] { (int)BS_0.Value, (int)BS_1.Value, (int)BS_2.Value, (int)BS_3.Value, (int)BS_4.Value, (int)BS_5.Value, }; }
            set
            {
                if (value.Length < 6) return;
                BS_0.Value = value[0]; BS_1.Value = value[1]; BS_2.Value = value[2];
                BS_3.Value = value[3]; BS_4.Value = value[4]; BS_5.Value = value[5];
            }
        }
        private int[] Stats
        {
            get { return new[] { (int)Stat0.Value, (int)Stat1.Value, (int)Stat2.Value, (int)Stat3.Value, (int)Stat4.Value, (int)Stat5.Value, }; }
            set
            {
                if (value.Length < 6) return;
                Stat0.Value = value[0]; Stat1.Value = value[1]; Stat2.Value = value[2];
                Stat3.Value = value[3]; Stat4.Value = value[4]; Stat5.Value = value[5];
            }
        }
        private NumericUpDown[] EventIV { get { return new[] { EventIV0, EventIV1, EventIV2, EventIV3, EventIV4, EventIV5, }; } }
        private CheckBox[] EventIVLocked { get { return new[] { Event_IV_Fix0, Event_IV_Fix1, Event_IV_Fix2, Event_IV_Fix3, Event_IV_Fix4, Event_IV_Fix5, }; } }
        private List<DataGridViewRow> dgvrowlist = new List<DataGridViewRow>();
    }
}