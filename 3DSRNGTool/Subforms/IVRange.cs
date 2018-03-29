using System.Windows.Forms;

namespace Pk3DSRNGTool
{
    public partial class IVRange : Form
    {
        public IVRange()
        {
            InitializeComponent();
            var t = new[] { "-", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, };
            this.H.Items.AddRange(t);
            this.A.Items.AddRange(t);
            this.B.Items.AddRange(t);
            this.C.Items.AddRange(t);
            this.D.Items.AddRange(t);
            this.S.Items.AddRange(t);
            Reset();
        }

        private void B_Save_Click(object sender, System.EventArgs e)
        {
            Hide();
            Program.mainform.IVlow = new[] {
            IVjudge(H.SelectedIndex, true),
            IVjudge(A.SelectedIndex, true),
            IVjudge(B.SelectedIndex, true),
            IVjudge(C.SelectedIndex, true),
            IVjudge(D.SelectedIndex, true),
            IVjudge(S.SelectedIndex, true),
            };
            Program.mainform.IVup = new[] {
            IVjudge(H.SelectedIndex, false),
            IVjudge(A.SelectedIndex, false),
            IVjudge(B.SelectedIndex, false),
            IVjudge(C.SelectedIndex, false),
            IVjudge(D.SelectedIndex, false),
            IVjudge(S.SelectedIndex, false),
            };
        }

        private int IVjudge(int selectindex, bool Islow)
        {
            switch (selectindex)
            {
                case 0: return Islow ? 0 : 31;
                case 1: return 31;
                case 2: return 30;
                case 3: return Islow ? 26 : 29;
                case 4: return Islow ? 16 : 25;
                case 5: return Islow ? 1 : 15;
                case 6: return 0;
                default: return 31;
            }
        }

        public void Reset()
        {
            H.SelectedIndex = A.SelectedIndex = B.SelectedIndex = C.SelectedIndex = D.SelectedIndex = S.SelectedIndex = 0;
        }

        public void Translate(string[] judge, string[] Stats)
        {
            L_H.Text = Stats[0];
            L_A.Text = Stats[1];
            L_B.Text = Stats[2];
            L_C.Text = Stats[3];
            L_D.Text = Stats[4];
            L_S.Text = Stats[5];
            for (int i = 1; i <= judge.Length; i++)
                H.Items[i] = A.Items[i] = B.Items[i] = C.Items[i] = D.Items[i] = S.Items[i] = judge[i - 1];
        }
    }
}
