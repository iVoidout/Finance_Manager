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
    public partial class RegisterForm : Form
    {
        private readonly DatabaseHelper _db;

        public RegisterForm(DatabaseHelper db)
        {
            InitializeComponent();
            _db = db;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("نام کاربری و گذرواژه را وارد کنید");
                return;
            }

            if (password != txtConfirm.Text)
            {
                MessageBox.Show("گذرواژه ها یکی نیستند");
                return;
            }

            if (password.Length < 4)
            {
                MessageBox.Show("گذرواژه میبایست حداقل 4 کارکتر باشد");
                return;
            }

            var hash = PasswordHelper.Hash(password);
            bool success = _db.RegisterUser(username, hash);

            if (!success)
            {
                MessageBox.Show("نام کاربری تکرای است");
                return;
            }

            MessageBox.Show("اکانت شما ساخته شد! میتوانید وارد شوید");
            this.Close();
        }
    }
}
