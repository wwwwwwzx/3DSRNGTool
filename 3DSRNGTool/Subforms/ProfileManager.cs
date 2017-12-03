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

            var t = new Profiles();
            t.WriteProfiles();
            t.ReadProfiles();

            D_Profiles.DataSource = new BindingSource { DataSource = t.GameProfiles };

        }
    }
}
