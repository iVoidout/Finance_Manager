using Finance_Tracker.Helpers;
using Finance_Tracker.Models;
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
    public partial class AdminForm : Form
    {
        private readonly DatabaseHelper _db;
        private readonly User _currentUser;
        private List<AppTransaction> _transactions;

        public AdminForm(DatabaseHelper db, User user)
        {
            InitializeComponent();
            _db = db;
            _currentUser = user;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی به این بخش را ندارید.");
                return;
            }

            var form = new CategoriesForm(_db, _currentUser.Id);
            form.ShowDialog();
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            new BudgetForm(_db).ShowDialog();
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            var form = new ApprovalForm(_db);
            form.ShowDialog();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            var form = new DepartmentForm(_db);
            form.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            new RegisterForm(_db).ShowDialog();
        }
    }
}
