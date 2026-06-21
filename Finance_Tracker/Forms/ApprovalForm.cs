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
using System.Transactions;
using System.Windows.Forms;

namespace Finance_Tracker.Forms
{
    public partial class ApprovalForm : Form
    {
        private readonly DatabaseHelper _db;
        private List<AppTransaction> _pending;
        public bool Changed { get; private set; } = false;
        public ApprovalForm(DatabaseHelper db)
        {
            InitializeComponent();
            _db = db;
        }

        private void ApprovalForm_Load(object sender, EventArgs e)
        {
            dgvPending.AutoGenerateColumns = false;
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "مبلغ", Width = 120, DefaultCellStyle = { Format = "N0" } });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "توضیحات", Width = 150 });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "دسته‌بندی", Width = 110 });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TypeDisplay", HeaderText = "نوع", Width = 55 });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Date", HeaderText = "تاریخ", Width = 100, DefaultCellStyle = { Format = "yyyy/MM/dd" } });
            dgvPending.Columns.Add(new DataGridViewTextBoxColumn{DataPropertyName = "DepartmentName", HeaderText = "دپارتمان", Width = 60});

            LoadPending();
        }

        private void LoadPending()
        {
            _pending = _db.GetPendingTransactions();
            foreach (var t in _pending)
                t.DepartmentName = _db.GetDepartmentName(t.DepartmentId);
            dgvPending.DataSource = null;
            dgvPending.DataSource = _pending;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateSelected("Approved");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateSelected("Rejected");
        }
        private void UpdateSelected(string status)
        {
            if (dgvPending.SelectedRows.Count == 0)
            {
                MessageBox.Show("یک تراکنش را انتخاب کنید.");
                return;
            }

            foreach (DataGridViewRow row in dgvPending.SelectedRows)
            {
                var t = (AppTransaction)row.DataBoundItem;
                _db.UpdateTransactionStatus(t.Id, status);
            }

            Changed = true;
            LoadPending();
        }

        private void dgvPending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
