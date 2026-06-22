using Finance_Tracker.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Finance_Tracker.Models;
using Finance_Tracker.Forms;

namespace Finance_Tracker.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseHelper _db;
        private readonly User _currentUser;
        private List<AppTransaction> _transactions;

        public MainForm(DatabaseHelper db, User user)
        {
            InitializeComponent();
            _db = db;
            _currentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = _currentUser.Username;
            lblUserRole.Text = _currentUser.Role == "Admin" ? "مدیر:" : "کارمند:";
            btnAdminPanel.Visible = _currentUser.Role == "Admin";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "مبلغ (تومان)",
                Width = 200,
                DefaultCellStyle = { Format = "N0" }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "توضیحات",
                Width = 200
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DepartmentName",
                HeaderText = "دپارتمان",
                Width = 80
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "دسته‌بندی",
                Width = 120
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TypeDisplay",
                HeaderText = "نوع",
                Width = 50
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "تاریخ",
                Width = 100,
                DefaultCellStyle = { Format = "yyyy/MM/dd" }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StatusDisplay",
                HeaderText = "وضعیت",
                Width = 76
            });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridView1.ColumnHeadersDefaultCellStyle.BackColor;

            lblTodayDate.Text = DateTime.Today.ToString("yyyy/MM/dd");

            dtpFrom.Font = new Font("Segoe UI", 9f);
            dtpTo.Font = new Font("Segoe UI", 9f);

            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;

            LoadFilterComboBoxes();
            LoadAllTransactionsForUser();

            cmbFilterType.Items.Add("نوع (همه)");
            cmbFilterType.Items.Add("درآمد");
            cmbFilterType.Items.Add("هزینه");
            cmbFilterType.SelectedIndex = 0;

        }
        private void LoadFilterComboBoxes()
        {
            var categories = _db.GetAllCategories();

            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("دسته بندی (همه)");
            cmbFilterCategory.Items.AddRange(categories.ToArray());
            cmbFilterCategory.SelectedIndex = 0;

            var departments = _db.GetDepartments();
            cmbFilterDepartment.Items.Clear();
            cmbFilterDepartment.Items.Add("دپارتمان (همه)");
            cmbFilterDepartment.Items.AddRange(departments.ToArray());
            cmbFilterDepartment.SelectedIndex = 0;
        }
        private void LoadAllTransactionsForUser()
        {
            _transactions = _currentUser.Role == "Admin" ? _db.GetAllTransactions() : _db.GetTransactions(_currentUser.Id);
            ApplyFilter();

            foreach (var t in _transactions)
                t.DepartmentName = _db.GetDepartmentName(t.DepartmentId);

            UpdateSummary();
        }
        private void UpdateSummary()
        {
            var approved = _transactions.Where(t => t.Status == "Approved").ToList();

            decimal income = approved.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal expense = approved.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            decimal balance = income - expense;

            lblBalance.Text = $"{FormatRial(balance)}";
            lblIncome.Text = $"{FormatRial(income)}";
            lblExpense.Text = $"{FormatRial(expense)}";
            pnlBalance.BackColor = balance >= 0 ? Color.Aqua  // green
                                        : ColorTranslator.FromHtml("#ff8080"); // red
        }
        private string FormatRial(decimal amount)
        {
            return string.Format("{0:N0} T", amount);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddTransactionForm(_db, _currentUser.Id, _currentUser.Role);
            form.ShowDialog();
            if (form.Saved)
            {
                LoadAllTransactionsForUser();
                ApplyFilter();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("یک ردیف را انتخاب کنید.");
                return;
            }

            var confirm = MessageBox.Show(
            $"ردیف های انتخاب شده ({dataGridView1.SelectedRows.Count}) حذف شود؟",
            "حذف",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var selected = (AppTransaction)row.DataBoundItem;
                _db.DeleteTransaction(selected.Id);
            }

            LoadAllTransactionsForUser();
            ApplyFilter();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("یک ردیف را انتخاب کنید.");
                return;
            }

            var selected = (AppTransaction)dataGridView1.SelectedRows[0].DataBoundItem;
            var form = new AddTransactionForm(_db, _currentUser.Id, _currentUser.Role, selected);
            form.ShowDialog();

            if (form.Saved)
            {
                LoadAllTransactionsForUser();
                ApplyFilter();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ignore header clicks
            btnEdit_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var approved = _transactions.Where(t => t.Status == "Approved").ToList();
            var filtered = approved.AsEnumerable();

            filtered = filtered.Where(t => t.Date.Date >= dtpFrom.Value.Date && t.Date.Date <= dtpTo.Value.Date);

            if (cmbFilterCategory.SelectedIndex > 0)
                filtered = filtered.Where(t => t.Category == cmbFilterCategory.SelectedItem.ToString());

            if (cmbFilterDepartment.SelectedIndex > 0)
                filtered = filtered.Where(t => t.DepartmentName == cmbFilterDepartment.SelectedItem.ToString());

            if (cmbFilterType.SelectedIndex == 1)
                filtered = filtered.Where(t => t.Type == "Income");
            else if (cmbFilterType.SelectedIndex == 2)
                filtered = filtered.Where(t => t.Type == "Expense");

            var result = filtered.ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result;

            UpdateFilterSummary(result);
        }
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            cmbFilterCategory.SelectedIndex = 0;
            cmbFilterType.SelectedIndex = 0;
            cmbFilterDepartment.SelectedIndex = 0;
            LoadAllTransactionsForUser();
        }

        private void UpdateFilterSummary(List<AppTransaction> filtered)
        {
            long income = filtered.Where(t => t.Type == "Income").Sum(t => t.Amount);
            long expense = filtered.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            long balance = income - expense;

            lblBalance.Text = $"{FormatRial(balance)}";
            lblIncome.Text = $"{FormatRial(income)}";
            lblExpense.Text = $"{FormatRial(expense)}";
            pnlBalance.BackColor = balance >= 0 ? Color.Aqua  // green
                                        : ColorTranslator.FromHtml("#ff8080"); // red
            //pnlBalance.BackColor = balance >= 0 ? ColorTranslator.FromHtml("#00ff6e")  // green
            //                            : ColorTranslator.FromHtml("#D40202"); // red
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bthCharts_Click(object sender, EventArgs e)
        {
            var currentlyShown = dataGridView1.DataSource as List<AppTransaction>;

            if (currentlyShown == null || currentlyShown.Count == 0)
            {
                MessageBox.Show(".هیچ تراکنشی برای نمایش وجود ندارد");
                return;
            }
            new ChartsForm(currentlyShown).ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("شما دسترسی به این بخش را ندارید.");
                return;
            }

            var form = new CategoriesForm(_db, _currentUser.Id);
            form.ShowDialog();

            if (form.CategoriesChanged)
                LoadFilterComboBoxes();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var data = dataGridView1.DataSource as List<AppTransaction>;

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("هیچ تراکنشی برای خروجی گرفتن وجود ندارد.");
                return;
            }

            var save = new SaveFileDialog();
            save.Filter = "CSV files (*.csv)|*.csv";
            save.FileName = $"report_{DateTime.Now:yyyyMMdd_HHmm}.csv";

            if (save.ShowDialog() != DialogResult.OK) return;

            var lines = new List<string>();
            lines.Add("توضیحات,مبلغ,دسته‌بندی,نوع,تاریخ,وضعیت");

            foreach (var t in data)
            {
                // wrap description in quotes in case it contains commas
                string desc = $"\"{t.Description.Replace("\"", "\"\"")}\"";
                lines.Add($"{desc},{t.Amount},{t.Category},{t.TypeDisplay},{t.Date:yyyy/MM/dd},{t.StatusDisplay}");
            }

            File.WriteAllLines(save.FileName, lines, new UTF8Encoding(true));

            MessageBox.Show(".فایل با موفقیت ذخیره شد");
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role == "Admin") 
            new AdminForm(_db, _currentUser).ShowDialog();

            LoadFilterComboBoxes();
            LoadAllTransactionsForUser();
            ApplyFilter();
        }
    }
}
