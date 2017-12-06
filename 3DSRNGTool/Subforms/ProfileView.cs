using System;
using System.Windows.Forms;
using static Pk3DSRNGTool.StringItem;

namespace Pk3DSRNGTool.Subforms
{
    public partial class ProfileView : Form
    {
        private bool Edit { get; set; }
        private Profiles.Profile Profile { get; set; }

        public ProfileView(bool _Edit = false, Profiles.Profile _Profile = null)
        {
            InitializeComponent();

            Edit = _Edit;
            Profile = _Profile;

            if (Edit)
            {
                Description.Text = Profile.Description;
                Gameversion.SelectedIndex = Profile.GameVersion;
                TSV.Value = Profile.TSV;
                ShinyCharm.Checked = Profile.ShinyCharm;
                Key3.Value = Profile.Seeds[3];
                Key2.Value = Profile.Seeds[2];
                Key1.Value = Profile.Seeds[1];
                Key0.Value = Profile.Seeds[0];
            }
            else
            { Gameversion.SelectedIndex = 0; }
            for (int i = 0; i < Gameversion.Items.Count; i++)
                Gameversion.Items[i] = GAMEVERSION_STR[language, i];
        }

        private void Gameversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var component = (ComboBox)sender;

            // Only allow 2 seeds
            if (component.SelectedIndex <= 4)
            {
                Key2.Enabled = false;
                Key3.Enabled = false;
            }
            // Allow all 4 seeds
            else
            {
                Key2.Enabled = true;
                Key3.Enabled = true;
            }
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Description.Text))
            {
                MessageBox.Show("Description field is empty!", "Empty field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newProfile = new Profiles.Profile()
            {
                Description = Description.Text,
                GameVersion = Gameversion.SelectedIndex,
                TSV = (ushort)TSV.Value,
                ShinyCharm = ShinyCharm.Checked,
                Seeds = new uint[]
                {
                    Key0.Value,
                    Key1.Value,
                    Key2.Value,
                    Key3.Value,
                }
            };

            if (Edit)
            {
                int i = Profiles.GameProfiles.IndexOf(Profile);
                Profiles.GameProfiles[i] = newProfile;
            }
            else
            {
                Profiles.GameProfiles.Add(newProfile);

            }

            Profiles.WriteProfiles();
            MessageBox.Show("Profiles updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }

        private void B_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_Current_Click(object sender, EventArgs e)
        {
            TSV.Value = Properties.Settings.Default.TSV;
            ShinyCharm.Checked = Properties.Settings.Default.ShinyCharm;
            if ((Gameversion.SelectedIndex = Program.mainform.Ver) > 4)
            {
                Key3.Value = Properties.Settings.Default.ST3;
                Key2.Value = Properties.Settings.Default.ST2;
                Key1.Value = Properties.Settings.Default.ST1;
                Key0.Value = Properties.Settings.Default.ST0;
            }
            else
            {
                Key1.Value = (uint)(Properties.Settings.Default.Key >> 32);
                Key0.Value = (uint)Properties.Settings.Default.Key;
            }
        }
    }
}
