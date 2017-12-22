using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static PKHeX.Util;
using static Pk3DSRNGTool.StringItem;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {
        // Reader
        private bool ReadWc(string filename)
        {
            BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open));
            try
            {
                bool valid;
                if (filename.Substring(filename.Length - 4, 4) == "full") // Trim full wc file
                {
                    br.ReadBytes(0x208);
                    filename = filename.Substring(0, filename.Length - 4);
                }
                if (Path.GetExtension(filename) != (Gen6 ? ".wc6" : ".wc7"))
                    valid = false;
                else
                    valid = Event_RawData(br.ReadBytes(0x108));
                br.Close();
                return valid;
            }
            catch
            {
                br.Close();
                return false;
            }
        }

        private bool Event_RawData(byte[] Data)
        {
            if (Data[0x51] != 0) return false; // CardType
            byte[] PIDType_Order = { 3, 0, 2, 1 };
            Event_Species.SelectedIndex = BitConverter.ToUInt16(Data, 0x82);
            Event_Forme.SelectedIndex = Data[0x84];
            AbilityLocked.Checked = Data[0xA2] < 3;
            Event_Ability.SelectedIndex = AbilityLocked.Checked ? Data[0xA2] + 1 : Data[0xA2] - 3;
            NatureLocked.Checked = Data[0xA0] != 0xFF;
            Event_Nature.SelectedIndex = NatureLocked.Checked ? Data[0xA0] : 0;
            GenderLocked.Checked = Data[0xA1] != 3;
            Event_Gender.SelectedIndex = GenderLocked.Checked ? (Data[0xA1] + 1) % 3 : 0;
            switch (Data[0xAF])
            {
                case 0xFE: IVsCount.Value = 3; break;
                case 0xFD: IVsCount.Value = 2; break;
                // Maybe more rules here
                default: IVsCount.Value = 0; break;
            }
            for (int i = 0; i < 6; i++)
            {
                if (Data[0xAF + Pokemon.Reorder2[i]] < 0xFD)
                {
                    EventIV[i].Value = Data[0xAF + Pokemon.Reorder2[i]];
                    EventIVLocked[i].Checked = true;
                }
                else
                {
                    EventIV[i].Value = 0;
                    EventIVLocked[i].Checked = false;
                }
            }
            Event_TID.Value = BitConverter.ToUInt16(Data, 0x68);
            Event_SID.Value = BitConverter.ToUInt16(Data, 0x6A);
            Event_PIDType.SelectedIndex = PIDType_Order[Data[0xA3]];
            if (Event_PIDType.SelectedIndex == 3)
                Event_PID.Value = BitConverter.ToUInt32(Data, 0xD4);
            Event_EC.Value = BitConverter.ToUInt32(Data, 0x70);
            if (Event_EC.Value > 0) Event_EC.Visible = L_EC.Visible = true;
            IsEgg.Checked = Data[0xD1] == 1;
            YourID.Checked = Data[0xB5] == 3;
            OtherInfo.Checked = true;
            Filter_Lv.Value = Data[0xD0];
            return true;
        }

        #region Event_UI
        private void B_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Filter = Gen6 ? "6th Gen Wonder Card File|*.wc6|Full Wonder Card File|*.wc6full"
                                          : "7th Gen Wonder Card File|*.wc7|Full Wonder Card File|*.wc7full",
                Title = "Select a Wonder Card File"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                if (!ReadWc(openFileDialog1.FileName))
                    Error(FILEERRORSTR[lindex]);
        }

        private void DropEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void DragDropWC(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && !ReadWc(files[0]))
                Error(FILEERRORSTR[lindex]);
        }

        private void IDChanged(object sender, EventArgs e)
        {
            L_Event_TSV.Text = "TSV:   ";
            uint EventTSV = ((uint)Event_TID.Value ^ (uint)Event_SID.Value) >> 4;
            L_Event_TSV.Text += EventTSV.ToString("D4");
            if (Gen6) return;
            string g7tid = "G7TID:  ";
            uint G7TID = ((uint)Event_TID.Value + ((uint)Event_SID.Value << 16)) % 1000000;
            g7tid += G7TID.ToString("D6");
            DGVToolTip.SetToolTip(L_TID, g7tid);
            DGVToolTip.SetToolTip(L_SID, g7tid);
            DGVToolTip.SetToolTip(Event_TID, g7tid);
            DGVToolTip.SetToolTip(Event_SID, g7tid);
        }

        private void NatureLocked_CheckedChanged(object sender, EventArgs e)
        {
            Event_Nature.Enabled = NatureLocked.Checked;
            if (!NatureLocked.Checked || Event_Nature.SelectedIndex < 0) Event_Nature.SelectedIndex = 0;
        }

        private void GenderLocked_CheckedChanged(object sender, EventArgs e)
        {
            Event_Gender.Enabled = GenderLocked.Checked;
            if (!GenderLocked.Checked) Event_Gender.SelectedIndex = 0;
        }

        private void AbilityLocked_CheckedChanged(object sender, EventArgs e)
        {
            Event_Ability.Items.Clear();
            Event_Ability.Items.AddRange(AbilityLocked.Checked ? StringItem.abilitynumstr : StringItem.eventabilitystr);
            Event_Ability.SelectedIndex = 0;
        }

        private void IVLocked_CheckedChanged(object sender, EventArgs e)
        {
            string str = ((CheckBox)sender).Name;
            int i = int.Parse(str.Remove(0, str.IndexOf("Fix", StringComparison.Ordinal) + 3));
            EventIV[i].Enabled = ((CheckBox)sender).Checked;
        }

        private void OtherInfo_CheckedChanged(object sender, EventArgs e)
        {
            L_Event_TSV.Visible = Event_EC.Enabled = Event_PID.Enabled = Event_TID.Enabled = Event_SID.Enabled = OtherInfo.Checked;
        }

        private void Event_PIDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!OtherInfo.Checked)
                Event_EC.Value = (uint)(Event_PIDType.SelectedIndex == 3 ? 0x12 : 0);
            L_EC.Visible = Event_EC.Visible = L_PID.Visible = Event_PID.Visible = Event_PIDType.SelectedIndex == 3;
        }

        private void Event_Species_SelectedIndexChanged(object sender, EventArgs e)
        {
            int species = Event_Species.SelectedIndex;
            if (species > 0)
            {
                RNGMethod.SelectedIndex = 1;
                int formcount = (Gen6 ? PersonalTable.ORAS : PersonalTable.USUM).getFormeEntry(species, 0).FormeCount;
                if (Pokemon.BattleForms.Contains(species))
                    formcount = 1;
                L_Forme.Visible = Event_Forme.Visible = formcount > 1;
                Event_Forme_SelectedIndexChanged(null, null);
                if (formcount == Event_Forme.Items.Count)
                    return;
                Event_Forme.Items.Clear();
                Event_Forme.Items.AddRange(new bool[formcount].Select((t, i) => i.ToString()).ToArray());
                Event_Forme.SelectedIndex = 0;
            }
        }

        private void Event_Forme_SelectedIndexChanged(object sender, EventArgs e)
        {
            int species = Event_Species.SelectedIndex;
            int forme = Event_Forme.SelectedIndex;
            SetPersonalInfo(species, forme);
            IVsCount.Value = Fix3v.Checked ? 3 : 0;
        }

        private int EventDelay => IsUltra ? 42 : 62;
        private void Event_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen7)
                Timedelay.Value = YourID.Checked && !IsEgg.Checked || NoDex.Checked ? EventDelay : 0;
            if (Gen6)
                Timedelay.Value = 0;
        }
        #endregion
    }
}
