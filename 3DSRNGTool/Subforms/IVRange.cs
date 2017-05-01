using System.Windows.Forms;

namespace Pk3DSRNGTool
{
    public partial class IVRange : Form
    {
        public MainForm parentform;
        public IVRange(MainForm form)
        {
            InitializeComponent();
            foreach (string t in Judge_Str)
            {
                this.H.Items.Add(t);
                this.A.Items.Add(t);
                this.B.Items.Add(t);
                this.C.Items.Add(t);
                this.D.Items.Add(t);
                this.S.Items.Add(t);
            }
            parentform = form;
            Reset();
        }

        private void B_Save_Click(object sender, System.EventArgs e)
        {
            Hide();
            parentform.IVlow = new[] {
            IVjudge(H.SelectedIndex, true),
            IVjudge(A.SelectedIndex, true),
            IVjudge(B.SelectedIndex, true),
            IVjudge(C.SelectedIndex, true),
            IVjudge(D.SelectedIndex, true),
            IVjudge(S.SelectedIndex, true),
            };
            parentform.IVup = new[] {
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

        public readonly static string[] Judge_Str = { "-", "最棒", "了不起", "非常好", "相当好", "一般般", "也许不行" };
        public readonly static string[] Stat_Str = { "HP", "攻击", "防御", "特攻", "特防", "速度" };
    }
}
