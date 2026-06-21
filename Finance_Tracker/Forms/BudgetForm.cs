using Finance_Tracker.Helpers;
using Microsoft.Data.Sqlite;
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
    public partial class BudgetForm : Form
    {
        private readonly DatabaseHelper _db;
        private readonly string[] _monthNamesGregorian = {
        "ژانویه", "فوریه", "مارس", "آپریل", "می", "ژوئن",
        "جولای", "آگوست", "سپتامبر", "اکتبر", "نوامبر", "دسامبر"
        };
        public BudgetForm(DatabaseHelper db)
        {
            InitializeComponent();
            _db = db;
        }

        private void BudgetForm_Load(object sender, EventArgs e)
        {

            dgvBudgets.AutoGenerateColumns = false;
            cmbMonth.Items.Clear();
            cmbMonth.Items.AddRange(_monthNamesGregorian);
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            numYear.Value = DateTime.Now.Year;

            cmbBudgetDept.Items.AddRange(_db.GetDepartments().ToArray());
            if (cmbBudgetDept.Items.Count > 0)
                cmbBudgetDept.SelectedIndex = 0;

            dgvBudgets.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DepartmentName", HeaderText = "دپارتمان", Width = 100 });
            dgvBudgets.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "بودجه", Width = 120, DefaultCellStyle = { Format = "N0" } });
            dgvBudgets.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Spent", HeaderText = "هزینه شده", Width = 120, DefaultCellStyle = { Format = "N0" } });

            LoadBudgets();
            txtBudgetAmount.MaxLength = 19;

            

        }

        private void LoadBudgets()
        {
            int year = (int)numYear.Value;
            int month = cmbMonth.SelectedIndex + 1;

            var budgets = _db.GetBudgets(year, month);

            foreach (var b in budgets)
            {
                b.Spent = _db.GetDepartmentSpending(b.DepartmentId, year, month);
            }

            dgvBudgets.DataSource = null;
            dgvBudgets.DataSource = budgets;
        }

        private void btnSetBudget_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtBudgetAmount.Text.Replace(",", ""), out long amount) || amount <= 0)
            {
                MessageBox.Show("مبلغ بودجه را به درستی وارد کنید.");
                return;
            }

            int deptId = _db.GetDepartmentId(cmbBudgetDept.SelectedItem.ToString());
            int year = (int)numYear.Value;
            int month = cmbMonth.SelectedIndex + 1;

            _db.SetBudget(deptId, year, month, amount);
            txtBudgetAmount.Clear();
            LoadBudgets();
        }
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBudgets();
        }
        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            LoadBudgets();
        }

        private void cmbBudgetDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool _isFormatting = false;

        private void txtBudgetAmount_TextChanged(object sender, EventArgs e)
        {
            if (_isFormatting) return;
            _isFormatting = true;

            var culture = System.Globalization.CultureInfo.InvariantCulture;
            string digits = txtBudgetAmount.Text.Replace(",", "");

            if (long.TryParse(digits, out long number))
            {
                int caretPos = txtBudgetAmount.SelectionStart;
                int oldLength = txtBudgetAmount.Text.Length;

                txtBudgetAmount.Text = number.ToString("N0", culture);

                int newLength = txtBudgetAmount.Text.Length;
                txtBudgetAmount.SelectionStart = Math.Max(0, caretPos + (newLength - oldLength));
            }

            else if (string.IsNullOrEmpty(digits))
            {
                txtBudgetAmount.Text = "";
            }

            _isFormatting = false;
        }

        private void txtBudgetAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
