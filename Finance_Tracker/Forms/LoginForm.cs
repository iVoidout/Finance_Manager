using Finance_Tracker.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance_Tracker.Forms
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseHelper _db;

        public LoginForm(DatabaseHelper db)
        {
            InitializeComponent();
            _db = db;
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            string path = "remember.txt";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                if (lines.Length >= 2)
                {
                    txtUsername.Text = lines[0];
                    txtPassword.Text = lines[1];
                    chkRemember.Checked = true;

                    // auto login
                    var user = _db.GetUser(lines[0]);
                    if (user != null && PasswordHelper.Verify(lines[1], user.PasswordHash))
                    {
                        this.Hide();
                        var mainForm = new MainForm(_db, user);
                        mainForm.ShowDialog();
                        if (mainForm.DialogResult != DialogResult.OK)
                            Application.Exit();
                        this.Show();
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _db.GetUser(txtUsername.Text.Trim());
            if (user == null || !PasswordHelper.Verify(txtPassword.Text, user.PasswordHash))
            {
                MessageBox.Show("نام کاربری یا گذرواژه نادرست است");
                return;
            }

            if (chkRemember.Checked)
                File.WriteAllLines("remember.txt", new[] { txtUsername.Text.Trim(), txtPassword.Text });
            else
                if (File.Exists("remember.txt")) File.Delete("remember.txt");

            this.Hide();
            var mainForm = new MainForm(_db, user);
            mainForm.ShowDialog();

            if (mainForm.DialogResult != DialogResult.OK)
                Application.Exit();

            this.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
        }

        private bool _passwordVisible = false;

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            _passwordVisible = !_passwordVisible;
            txtPassword.PasswordChar = _passwordVisible ? '\0' : '•';
            btnShowPass.Text = _passwordVisible ? "◉" : "◎";
        }

        private void btnShowPass_Click_1(object sender, EventArgs e)
        {

        }
    }
}
