using System;
using System.Windows.Forms;

namespace Pk3DSRNGTool.Subforms
{
    public partial class ProfileManager : Form
    {
        public ProfileManager()
        {
            InitializeComponent();

            D_Profiles.DataSource = new BindingSource { DataSource = Profiles.GameProfiles };
        }

        private void B_Add_Click(object sender, EventArgs e)
        {
            new ProfileView().ShowDialog();
        }

        private void B_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                var row = D_Profiles.CurrentRow;

                if (row != null)
                {
                    var selected = (Profiles.Profile)row.DataBoundItem;

                    new ProfileView(selected).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select a proper row to edit! Error: " + ex.Message);
            }
        }

        private void B_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                var row = D_Profiles.CurrentRow;

                if (row != null)
                {
                    var selected = (Profiles.Profile)row.DataBoundItem;

                    if (MessageBox.Show("Are you sure?", "Remove profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        Profiles.GameProfiles.Remove(selected);
                        Profiles.WriteProfiles();

                        MessageBox.Show("Successfully removed!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select a proper row to remove! Error: " + ex.Message);
            }
        }

        private void B_up_Click(object sender, EventArgs e)
        {
            try
            {
                var row = D_Profiles.CurrentRow;

                if (row != null)
                {
                    var selected = (Profiles.Profile)row.DataBoundItem;
                    int idx = row.Index;
                    if (idx > 0)
                    {
                        Profiles.GameProfiles.Remove(selected);
                        Profiles.GameProfiles.Insert(idx - 1, selected);
                        D_Profiles.Rows[idx - 1].Selected = true;
                        D_Profiles.CurrentCell = D_Profiles.Rows[idx - 1].Cells[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select a proper row to edit! Error: " + ex.Message);
            }

        }

        private void B_Down_Click(object sender, EventArgs e)
        {
            try
            {
                var row = D_Profiles.CurrentRow;

                if (row != null)
                {
                    var selected = (Profiles.Profile)row.DataBoundItem;
                    int idx = row.Index;
                    if (idx < Profiles.GameProfiles.Count - 1)
                    {
                        Profiles.GameProfiles.Remove(selected);
                        Profiles.GameProfiles.Insert(idx + 1, selected);
                        D_Profiles.Rows[idx + 1].Selected = true;
                        D_Profiles.CurrentCell = D_Profiles.Rows[idx + 1].Cells[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select a proper row to edit! Error: " + ex.Message);
            }
        }
    }
}
