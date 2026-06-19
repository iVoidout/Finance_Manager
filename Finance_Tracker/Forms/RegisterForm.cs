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

            cmbRole.Items.Add("کارمند");
            cmbRole.Items.Add("مدیر");
            cmbRole.SelectedIndex = 0;

            cmbDepartment.Items.AddRange(_db.GetDepartments().ToArray());
            if (cmbDepartment.Items.Count > 0)
                cmbDepartment.SelectedIndex = 0;
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
            string role = cmbRole.SelectedIndex == 1 ? "Admin" : "Employee";
            int deptId = _db.GetDepartmentId(cmbDepartment.SelectedItem.ToString());
            bool success = _db.RegisterUser(username, hash, role, deptId);

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
