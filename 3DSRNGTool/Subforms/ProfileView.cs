using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
                Key3.Value = Profile.Seeds.Key3;
                Key2.Value = Profile.Seeds.Key2;
                Key1.Value = Profile.Seeds.Key1;
                Key0.Value = Profile.Seeds.Key0;
            }
            else
            { Gameversion.SelectedIndex = 0; }
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
                Seeds = new Profiles.EggSeeds()
                {
                    Key0 = Key0.Value,
                    Key1 = Key1.Value,
                    Key2 = Key2.Value,
                    Key3 = Key3.Value
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
    }
}
