using Finance_Tracker.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using Finance_Tracker.Models;

namespace Finance_Tracker.Forms
{
    public partial class AddTransactionForm : Form
    {
        private readonly DatabaseHelper _db;
        private readonly int _userId;
        private readonly int _transactionId;
        private readonly AppTransaction _existing;
        private readonly string _currentUserRole;

        public bool Saved { get; private set; } = false;

        public AddTransactionForm(DatabaseHelper db, int userId, string role, AppTransaction existing = null)
        {
            InitializeComponent();
            _db = db;
            _userId = userId;
            _currentUserRole = role;
            _existing = existing;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtAmount.Text.Replace(",", ""), out long amount) || amount <= 0)
            {
                MessageBox.Show(".لطفاً یک مبلغ معتبر وارد کنید");
                return;
            }

            var transaction = new AppTransaction
            {
                Description = txtDescription.Text.Trim(),
                Amount = amount,
                Category = cmbCategory.SelectedItem.ToString(),
                Date = dtpDate.Value,
                Type = rbIncome.Checked ? "Income" : "Expense",
                DepartmentId = _db.GetDepartmentId(cmbDepartment.SelectedItem.ToString())
            };

            if (_existing != null)
            {
                transaction.Id = _existing.Id;
                _db.UpdateTransaction(transaction);
            }
            else
            {
                _db.AddTransaction(_userId, transaction, _currentUserRole);
            }

            Saved = true;
            this.Close();
        }

        private void addTransactionForm_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(_db.GetCategories().ToArray());
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;

            cmbDepartment.Items.AddRange(_db.GetDepartments().ToArray());
            cmbDepartment.SelectedIndex = 0; 

            rbExpense.Checked = true;

            txtAmount.MaxLength = 19;

            dtpDate.Font = new Font("Segoe UI", 10f);
            dtpDate.CalendarFont = new Font("Segoe UI", 10f);
            dtpDate.Value = DateTime.Today;

            if (_existing != null)
            {
                txtDescription.Text = _existing.Description;
                txtAmount.Text = _existing.Amount.ToString("N0",
                                            System.Globalization.CultureInfo.InvariantCulture);
                dtpDate.Value = _existing.Date;
                rbIncome.Checked = _existing.Type == "Income";
                rbExpense.Checked = _existing.Type == "Expense";

                int idx = cmbCategory.Items.IndexOf(_existing.Category);
                cmbCategory.SelectedIndex = idx >= 0 ? idx : 0;

                this.Text = "ویرایش تراکنش";
                btnSave.Text = "بروزرسانی";
            }

        }

        private void rbIncome_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _isFormatting = false;
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (_isFormatting) return;
            _isFormatting = true;

            var culture = System.Globalization.CultureInfo.InvariantCulture;
            string digits = txtAmount.Text.Replace(",", "");

            if (long.TryParse(digits, out long number))
            {
                int caretPos = txtAmount.SelectionStart;
                int oldLength = txtAmount.Text.Length;

                txtAmount.Text = number.ToString("N0", culture);

                int newLength = txtAmount.Text.Length;
                txtAmount.SelectionStart = Math.Max(0, caretPos + (newLength - oldLength));
            }

            else if (string.IsNullOrEmpty(digits))
            {
                txtAmount.Text = "";
            }

            _isFormatting = false;

        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
