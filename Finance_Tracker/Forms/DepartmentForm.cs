using Finance_Tracker.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker.Forms
{
    public partial class DepartmentForm : Form
    {
        private readonly DatabaseHelper _db;
        public bool Changed { get; private set; } = false;
        public bool CategoriesChanged { get; private set; } = false;

        public DepartmentForm(DatabaseHelper db)
        {
            InitializeComponent();
            _db = db;
        }

        private void SettingsFrom_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            lstDepartments.Items.Clear();
            foreach (var d in _db.GetDepartments())
                lstDepartments.Items.Add(d);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtNewDepartment.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("نام دپارتمان را وارد کنید.");
                return;
            }

            if (lstDepartments.Items.Contains(name))
            {
                MessageBox.Show("این دپارتمان قبلاً وجود دارد.");
                return;
            }

            _db.AddDepartment(name);
            txtNewDepartment.Clear();
            Changed = true;
            LoadDepartments();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lstDepartments.SelectedItem == null)
            {
                MessageBox.Show("یک دپارتمان را انتخاب کنید.");
                return;
            }

            var confirm = MessageBox.Show(
                "حذف این دپارتمان باعث حذف آن از کاربران یا تراکنش‌های قبلی نمی‌شود. ادامه می‌دهید؟",
                "حذف دپارتمان",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            _db.DeleteDepartment(lstDepartments.SelectedItem.ToString());
            Changed = true;
            LoadDepartments();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
