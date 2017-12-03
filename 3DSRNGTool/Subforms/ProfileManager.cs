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
    public partial class ProfileManager : Form
    {
        public ProfileManager()
        {
            InitializeComponent();

            D_Profiles.DataSource = new BindingSource { DataSource = Profiles.GameProfiles };
        }

        private void M_Add_Click(object sender, EventArgs e)
        {
            new ProfileView().ShowDialog();
        }

        private void M_Edit_Click(object sender, EventArgs e)
        {
            new ProfileView(true).ShowDialog();
        }

        private void M_Remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Remove profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                // Remove :)
            }
        }
    }
}
