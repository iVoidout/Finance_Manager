namespace Finance_Tracker.Forms
{
    partial class BudgetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            cmbMonth = new ComboBox();
            numYear = new NumericUpDown();
            dgvBudgets = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            cmbBudgetDept = new ComboBox();
            label3 = new Label();
            txtBudgetAmount = new TextBox();
            label4 = new Label();
            btnClose = new Finance_Tracker.Controls.PrimaryButton();
            btnSetBudget = new Finance_Tracker.Controls.PrimaryButton();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBudgets).BeginInit();
            SuspendLayout();
            // 
            // cmbMonth
            // 
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(12, 208);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(180, 23);
            cmbMonth.TabIndex = 0;
            // 
            // numYear
            // 
            numYear.Location = new Point(206, 209);
            numYear.Maximum = new decimal(new int[] { 2999, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(150, 23);
            numYear.TabIndex = 1;
            numYear.Value = new decimal(new int[] { 2020, 0, 0, 0 });
            numYear.ValueChanged += numYear_ValueChanged;
            // 
            // dgvBudgets
            // 
            dgvBudgets.AllowUserToAddRows = false;
            dgvBudgets.AllowUserToDeleteRows = false;
            dgvBudgets.AllowUserToResizeRows = false;
            dgvBudgets.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBudgets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBudgets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Shabnam", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBudgets.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBudgets.GridColor = Color.White;
            dgvBudgets.Location = new Point(12, 12);
            dgvBudgets.Name = "dgvBudgets";
            dgvBudgets.ReadOnly = true;
            dgvBudgets.RowHeadersVisible = false;
            dgvBudgets.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvBudgets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBudgets.Size = new Size(344, 176);
            dgvBudgets.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(206, 190);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 3;
            label1.Text = "سال";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 190);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 3;
            label2.Text = "ماه";
            // 
            // cmbBudgetDept
            // 
            cmbBudgetDept.FormattingEnabled = true;
            cmbBudgetDept.Location = new Point(206, 264);
            cmbBudgetDept.Name = "cmbBudgetDept";
            cmbBudgetDept.Size = new Size(150, 23);
            cmbBudgetDept.TabIndex = 4;
            cmbBudgetDept.SelectedIndexChanged += cmbBudgetDept_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(235, 246);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 3;
            label3.Text = "دپارتمان";
            label3.Click += label3_Click;
            // 
            // txtBudgetAmount
            // 
            txtBudgetAmount.Location = new Point(12, 264);
            txtBudgetAmount.Name = "txtBudgetAmount";
            txtBudgetAmount.Size = new Size(180, 23);
            txtBudgetAmount.TabIndex = 5;
            txtBudgetAmount.TextChanged += txtBudgetAmount_TextChanged;
            txtBudgetAmount.KeyPress += txtBudgetAmount_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 246);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 3;
            label4.Text = "مبلغ بودجه";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Cyan;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Shabnam", 9.75F);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(151, 342);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 27);
            btnClose.TabIndex = 6;
            btnClose.TabStop = false;
            btnClose.Text = "بستن";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSetBudget
            // 
            btnSetBudget.BackColor = Color.Cyan;
            btnSetBudget.FlatAppearance.BorderSize = 0;
            btnSetBudget.FlatStyle = FlatStyle.Flat;
            btnSetBudget.Font = new Font("Shabnam", 9.75F);
            btnSetBudget.ForeColor = Color.Black;
            btnSetBudget.Location = new Point(118, 303);
            btnSetBudget.Name = "btnSetBudget";
            btnSetBudget.Size = new Size(138, 27);
            btnSetBudget.TabIndex = 7;
            btnSetBudget.TabStop = false;
            btnSetBudget.Text = "ذخیره بودجه";
            btnSetBudget.UseVisualStyleBackColor = false;
            btnSetBudget.Click += btnSetBudget_Click;
            // 
            // BudgetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 380);
            Controls.Add(btnSetBudget);
            Controls.Add(btnClose);
            Controls.Add(txtBudgetAmount);
            Controls.Add(cmbBudgetDept);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvBudgets);
            Controls.Add(numYear);
            Controls.Add(cmbMonth);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "BudgetForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "تنظیم بودجه";
            Load += BudgetForm_Load;
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBudgets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMonth;
        private NumericUpDown numYear;
        private DataGridView dgvBudgets;
        private Label label1;
        private Label label2;
        private ComboBox cmbBudgetDept;
        private Label label3;
        private TextBox txtBudgetAmount;
        private Label label4;
        private Controls.PrimaryButton btnClose;
        private Controls.PrimaryButton btnSetBudget;
    }
}