
namespace HelloPam.WinForms
{
    partial class FrmUserEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.save_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.status_ckb = new System.Windows.Forms.CheckBox();
            this.image_ptb = new System.Windows.Forms.PictureBox();
            this.linkLabel1_lkl = new System.Windows.Forms.LinkLabel();
            this.fullname_txt = new System.Windows.Forms.TextBox();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.profile_cbx = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.remove_lkl = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.image_ptb)).BeginInit();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(247, 305);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(189, 35);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Full name";
            // 
            // status_ckb
            // 
            this.status_ckb.AutoSize = true;
            this.status_ckb.Checked = true;
            this.status_ckb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.status_ckb.Location = new System.Drawing.Point(12, 316);
            this.status_ckb.Name = "status_ckb";
            this.status_ckb.Size = new System.Drawing.Size(78, 24);
            this.status_ckb.TabIndex = 2;
            this.status_ckb.Text = "Enable";
            this.status_ckb.UseVisualStyleBackColor = true;
            this.status_ckb.CheckedChanged += new System.EventHandler(this.status_ckb_CheckedChanged);
            // 
            // image_ptb
            // 
            this.image_ptb.BackColor = System.Drawing.SystemColors.Control;
            this.image_ptb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_ptb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image_ptb.Location = new System.Drawing.Point(247, 51);
            this.image_ptb.Name = "image_ptb";
            this.image_ptb.Size = new System.Drawing.Size(189, 232);
            this.image_ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_ptb.TabIndex = 3;
            this.image_ptb.TabStop = false;
            this.toolTip1.SetToolTip(this.image_ptb, "Click to choose image");
            this.image_ptb.Click += new System.EventHandler(this.image_ptb_Click);
            // 
            // linkLabel1_lkl
            // 
            this.linkLabel1_lkl.AutoSize = true;
            this.linkLabel1_lkl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1_lkl.Location = new System.Drawing.Point(178, 170);
            this.linkLabel1_lkl.Name = "linkLabel1_lkl";
            this.linkLabel1_lkl.Size = new System.Drawing.Size(38, 15);
            this.linkLabel1_lkl.TabIndex = 4;
            this.linkLabel1_lkl.TabStop = true;
            this.linkLabel1_lkl.Text = "Show";
            this.linkLabel1_lkl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_lkl_LinkClicked);
            // 
            // fullname_txt
            // 
            this.fullname_txt.Location = new System.Drawing.Point(12, 51);
            this.fullname_txt.Name = "fullname_txt";
            this.fullname_txt.Size = new System.Drawing.Size(204, 26);
            this.fullname_txt.TabIndex = 5;
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(12, 122);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(204, 26);
            this.username_txt.TabIndex = 6;
            // 
            // password_txt
            // 
            this.password_txt.Location = new System.Drawing.Point(12, 190);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(204, 26);
            this.password_txt.TabIndex = 7;
            this.password_txt.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Profile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Picture";
            // 
            // profile_cbx
            // 
            this.profile_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profile_cbx.FormattingEnabled = true;
            this.profile_cbx.Location = new System.Drawing.Point(12, 257);
            this.profile_cbx.Name = "profile_cbx";
            this.profile_cbx.Size = new System.Drawing.Size(204, 28);
            this.profile_cbx.TabIndex = 13;
            // 
            // remove_lkl
            // 
            this.remove_lkl.AutoSize = true;
            this.remove_lkl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_lkl.LinkColor = System.Drawing.Color.Red;
            this.remove_lkl.Location = new System.Drawing.Point(421, 31);
            this.remove_lkl.Name = "remove_lkl";
            this.remove_lkl.Size = new System.Drawing.Size(15, 16);
            this.remove_lkl.TabIndex = 14;
            this.remove_lkl.TabStop = true;
            this.remove_lkl.Text = "x";
            this.toolTip1.SetToolTip(this.remove_lkl, "Click to remove image");
            this.remove_lkl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.remove_lkl_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 360);
            this.Controls.Add(this.remove_lkl);
            this.Controls.Add(this.profile_cbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.fullname_txt);
            this.Controls.Add(this.linkLabel1_lkl);
            this.Controls.Add(this.image_ptb);
            this.Controls.Add(this.status_ckb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save_btn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User edit";
            ((System.ComponentModel.ISupportInitialize)(this.image_ptb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox status_ckb;
        private System.Windows.Forms.PictureBox image_ptb;
        private System.Windows.Forms.LinkLabel linkLabel1_lkl;
        private System.Windows.Forms.TextBox fullname_txt;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox profile_cbx;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel remove_lkl;
    }
}