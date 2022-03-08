using HelloPam.BO;
using System;
using System.Windows.Forms;

namespace HelloPam.WinForms
{
    public partial class FrmHome : Form
    {
        private User user;

        public FrmHome()
        {
            InitializeComponent();
            Date_stp.Text = DateTime.Now.ToString();
            User_stp.Text = "";
        }

        public FrmHome(User user):this()
        {
            this.user = user;
            User_stp.Text = $"{user.Fullname} - {user.Profile}";
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmUserEdit form = new FrmUserEdit();
            form.MdiParent = this;
            form.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserList form = new FrmUserList();
            form.MdiParent = this;
            form.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmLogin(this.user).Show();
            this.Close();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
