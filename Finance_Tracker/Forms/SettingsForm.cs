using Finance_Tracker.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly DatabaseHelper _db;
        private readonly int _userId;
        public bool CategoriesChanged { get; private set; } = false;

        public SettingsForm(DatabaseHelper db, int userId)
        {
            InitializeComponent();
            _db = db;
            _userId = userId;
        }

        private void SettingsFrom_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            lstCategories.Items.Clear();
            foreach (var cat in _db.GetCategories())
                lstCategories.Items.Add(cat);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtNewCategory.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("نام دسته‌بندی را وارد کنید.");
                return;
            }

            if (lstCategories.Items.Contains(name))
            {
                MessageBox.Show("این دسته‌بندی قبلاً وجود دارد.");
                return;
            }

            _db.AddCategory(name);
            txtNewCategory.Clear();
            CategoriesChanged = true;
            LoadCategories();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null)
            {
                MessageBox.Show("یک دسته‌بندی را انتخاب کنید.");
                return;
            }

            var confirm = MessageBox.Show(
                "حذف این دسته‌بندی باعث حذف آن از تراکنش‌های قبلی نمی‌شود. ادامه می‌دهید؟",
                "حذف دسته‌بندی",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            _db.DeleteCategory(lstCategories.SelectedItem.ToString());
            CategoriesChanged = true;
            LoadCategories();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
