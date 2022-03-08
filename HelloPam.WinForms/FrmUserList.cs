using HelloPam.BLL;
using HelloPam.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HelloPam.WinForms
{
    public partial class FrmUserList : Form
    {
        private UserBLO userBLO;

        public FrmUserList()
        {
            InitializeComponent();
            userBLO = new UserBLO();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void LoadData(IEnumerable<User> users)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users;
            Item_lbl.Text = $"{dataGridView1.Rows.Count} item(s)";
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            textBox1_txt.Clear();
            this.LoadData(userBLO.FindUser(new User()));
        }

        private void textBox1_txt_TextChanged(object sender, EventArgs e)
        {
            User user = new User { Username = textBox1_txt.Text };
            var user1 = this.userBLO.FindUser(user);

            user = new User { Fullname = textBox1_txt.Text };
            var user2 = this.userBLO.FindUser(user);

            LoadData(user1.Union(user2).ToList());
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1_txt.Clear();
            this.LoadData(userBLO.FindUser(new User()));
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserEdit form = new FrmUserEdit(LoadData);
            form.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                User user = dataGridView1.SelectedRows[0].DataBoundItem as User;
                FrmUserEdit form = new FrmUserEdit(LoadData, user);
                form.Show();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Confirm if you want to delete","",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        User user = dataGridView1.SelectedRows[i].DataBoundItem as User;
                        this.userBLO.DeleteUser(user.Id);
                    }
                    MessageBox.Show("Done !");
                }
                this.LoadData(userBLO.FindUser(new User()));
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }
    }
}
