using HelloPam.BLL;
using HelloPam.BO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HelloPam.WinForms
{
    public partial class FrmUserEdit : Form
    {
        private readonly Action<IEnumerable<User>> callback;
        private readonly User user;
        private readonly UserBLO userBLO;

        public FrmUserEdit()
        {
            InitializeComponent();
            InitForm();
            this.userBLO = new UserBLO();
        }
        public FrmUserEdit(Action<IEnumerable<User>> callback):this()
        {
            this.callback = callback;
        }
        public FrmUserEdit(Action<IEnumerable<User>> callback, User user) : this(callback)
        {
            this.user = user;
            fullname_txt.Text = user.Fullname;
            password_txt.Text = user.Password;
            username_txt.Text = user.Username;
            profile_cbx.SelectedIndex = (int)user.Profile;
            status_ckb.Checked = user.Status ?? false;
            if (user.Picture != null)
                image_ptb.Image = Bitmap.FromStream(new MemoryStream(user.Picture));
        }
        private void InitForm()
        {
            fullname_txt.Clear();
            password_txt.Clear();
            username_txt.Clear();
            password_txt.UseSystemPasswordChar = true;
            linkLabel1_lkl.Text = "Show";
            profile_cbx.DataSource = Enum.GetNames(typeof(ProfileOptions));
            profile_cbx.SelectedIndex = -1;
            status_ckb.Text = "Enable";
            status_ckb.Checked = true;
            image_ptb.Image = null;
            image_ptb.ImageLocation = null;
            fullname_txt.Focus();
        }
        private void linkLabel1_lkl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1_lkl.Text = linkLabel1_lkl.Text == "Show" ? "Hide" : "Show";
            password_txt.UseSystemPasswordChar = !password_txt.UseSystemPasswordChar;
        }

        private void status_ckb_CheckedChanged(object sender, EventArgs e)
        {
            status_ckb.Text = status_ckb.Checked ? "Enable" : "Disable";
        }

        private void image_ptb_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose image";
            openFileDialog1.FileName = "Images";
            openFileDialog1.Filter = "Images(*.jpg;*.jpeg;*.png;*.gif)| *.jpg; *.jpeg; *.png; *.gif|tous(*.)|*";
            openFileDialog1.Multiselect = false;
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                try
                {
                    image_ptb.ImageLocation = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void remove_lkl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            image_ptb.ImageLocation = null;
            image_ptb.Image = null;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            byte[] picture = this.user?.Picture;
            if (!string.IsNullOrEmpty(image_ptb.ImageLocation) && File.Exists(image_ptb.ImageLocation))
            {
                picture = File.ReadAllBytes(image_ptb.ImageLocation);
            }
            try
            {
                User newUser = new User
                    (
                        this.user?.Id ?? 0,
                        username_txt.Text,
                        password_txt.Text,
                        fullname_txt.Text,
                        picture,
                        (ProfileOptions?)profile_cbx.SelectedIndex,
                        status_ckb.Checked,
                        DateTime.Now
                    );
                if (this.user == null)
                    this.userBLO.CreateUser(newUser);
                else
                    this.userBLO.EditUser(newUser);
                MessageBox.Show("Save done !");
                InitForm();
                if (this.callback != null)
                    this.callback(userBLO.FindUser(new User()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
