using HelloPam.BLL;
using HelloPam.BO;
using System;
using System.Windows.Forms;

namespace HelloPam.WinForms
{
    public partial class FrmLogin : Form
    {
        private readonly UserBLO userBLO;

        public FrmLogin()
        {
            InitializeComponent();
            this.userBLO = new UserBLO();
        }
        public FrmLogin(User user):this()
        {
            Username_txt.Text = user.Username;
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var user = this.userBLO.AuthenticateUser(Username_txt.Text, Password_txt.Text);
                new FrmHome(user).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
