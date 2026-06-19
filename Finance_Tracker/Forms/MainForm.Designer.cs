namespace Finance_Tracker.Forms
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            lblBalance = new Label();
            lblIncome = new Label();
            lblExpense = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnLogout = new Button();
            panel1 = new Panel();
            lblTodayDate = new Label();
            lblUsername = new Label();
            label5 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            bthCharts = new Button();
            btnEdit = new Button();
            filterPanel = new Panel();
            label7 = new Label();
            label6 = new Label();
            btnClearFilter = new Button();
            btnFilter = new Button();
            cmbFilterType = new ComboBox();
            cmbFilterCategory = new ComboBox();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            pnlExpense = new Panel();
            pnlIncome = new Panel();
            pnlBalance = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            filterPanel.SuspendLayout();
            pnlExpense.SuspendLayout();
            pnlIncome.SuspendLayout();
            pnlBalance.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Shabnam", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(216, 239, 227);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(26, 26, 46);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView1.Location = new Point(0, 77);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.SelectionBackColor = Color.Cyan;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(750, 331);
            dataGridView1.TabIndex = 0;
            dataGridView1.TabStop = false;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(4, 12);
            lblBalance.Margin = new Padding(4, 0, 4, 0);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(79, 21);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "lblBalance";
            lblBalance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIncome
            // 
            lblIncome.AutoSize = true;
            lblIncome.Location = new Point(4, 12);
            lblIncome.Margin = new Padding(4, 0, 4, 0);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new Size(76, 21);
            lblIncome.TabIndex = 1;
            lblIncome.Text = "lblIncome";
            lblIncome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblExpense
            // 
            lblExpense.AutoSize = true;
            lblExpense.Location = new Point(0, 12);
            lblExpense.Margin = new Padding(4, 0, 4, 0);
            lblExpense.Name = "lblExpense";
            lblExpense.Size = new Size(82, 21);
            lblExpense.TabIndex = 1;
            lblExpense.Text = "lblExpense";
            lblExpense.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Cyan;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Shabnam", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(659, 10);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 30);
            btnAdd.TabIndex = 2;
            btnAdd.TabStop = false;
            btnAdd.Text = "اضافه";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.Black;
            btnDelete.Location = new Point(482, 10);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 30);
            btnDelete.TabIndex = 2;
            btnDelete.TabStop = false;
            btnDelete.Text = "حذف";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(198, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 21);
            label1.TabIndex = 3;
            label1.Text = "درآمد:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(190, 10);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 21);
            label2.TabIndex = 3;
            label2.Text = "هزینه:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(165, 10);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 3;
            label3.Text = "باقی مانده:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Cyan;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(12, 8);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 2;
            btnLogout.TabStop = false;
            btnLogout.Text = "خروج";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblTodayDate);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnLogout);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(749, 39);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // lblTodayDate
            // 
            lblTodayDate.AutoSize = true;
            lblTodayDate.Location = new Point(302, 13);
            lblTodayDate.Margin = new Padding(4, 0, 4, 0);
            lblTodayDate.Name = "lblTodayDate";
            lblTodayDate.Size = new Size(77, 15);
            lblTodayDate.TabIndex = 6;
            lblTodayDate.Text = "yyyy/mm/dd";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(623, 12);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(73, 15);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "lblUsername";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(376, 12);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 3;
            label5.Text = "تاریخ امروز:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(694, 12);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 3;
            label4.Text = "کاربر:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(bthCharts);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnAdd);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 461);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(749, 52);
            panel2.TabIndex = 5;
            // 
            // bthCharts
            // 
            bthCharts.BackColor = Color.Cyan;
            bthCharts.FlatAppearance.BorderSize = 0;
            bthCharts.FlatStyle = FlatStyle.Flat;
            bthCharts.Location = new Point(13, 10);
            bthCharts.Margin = new Padding(4, 3, 4, 3);
            bthCharts.Name = "bthCharts";
            bthCharts.Size = new Size(75, 30);
            bthCharts.TabIndex = 5;
            bthCharts.Text = "نمودارها";
            bthCharts.UseVisualStyleBackColor = false;
            bthCharts.Click += bthCharts_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Cyan;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Shabnam", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.Black;
            btnEdit.Location = new Point(570, 10);
            btnEdit.Margin = new Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 30);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "ویرایش";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.Transparent;
            filterPanel.Controls.Add(label7);
            filterPanel.Controls.Add(label6);
            filterPanel.Controls.Add(btnClearFilter);
            filterPanel.Controls.Add(btnFilter);
            filterPanel.Controls.Add(cmbFilterType);
            filterPanel.Controls.Add(cmbFilterCategory);
            filterPanel.Controls.Add(dtpFrom);
            filterPanel.Controls.Add(dtpTo);
            filterPanel.Location = new Point(0, 38);
            filterPanel.Margin = new Padding(4, 3, 4, 3);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(750, 42);
            filterPanel.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Shabnam", 9F);
            label7.Location = new Point(126, 12);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(14, 16);
            label7.TabIndex = 4;
            label7.Text = "تا";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Shabnam", 9F);
            label6.Location = new Point(261, 12);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(15, 16);
            label6.TabIndex = 4;
            label6.Text = "از";
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.FromArgb(255, 128, 128);
            btnClearFilter.Cursor = Cursors.Hand;
            btnClearFilter.FlatAppearance.BorderSize = 0;
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.Font = new Font("Shabnam", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearFilter.ForeColor = Color.Black;
            btnClearFilter.Location = new Point(657, 9);
            btnClearFilter.Margin = new Padding(4, 3, 4, 3);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(75, 23);
            btnClearFilter.TabIndex = 3;
            btnClearFilter.Text = "حذف فیلتر";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.Cyan;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Shabnam", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.Black;
            btnFilter.Location = new Point(576, 9);
            btnFilter.Margin = new Padding(4, 3, 4, 3);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "فیلتر";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // cmbFilterType
            // 
            cmbFilterType.Cursor = Cursors.Hand;
            cmbFilterType.FormattingEnabled = true;
            cmbFilterType.Location = new Point(450, 8);
            cmbFilterType.Margin = new Padding(4, 3, 4, 3);
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(93, 23);
            cmbFilterType.TabIndex = 2;
            // 
            // cmbFilterCategory
            // 
            cmbFilterCategory.Cursor = Cursors.Hand;
            cmbFilterCategory.FormattingEnabled = true;
            cmbFilterCategory.Location = new Point(309, 8);
            cmbFilterCategory.Margin = new Padding(4, 3, 4, 3);
            cmbFilterCategory.Name = "cmbFilterCategory";
            cmbFilterCategory.Size = new Size(135, 23);
            cmbFilterCategory.TabIndex = 1;
            // 
            // dtpFrom
            // 
            dtpFrom.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFrom.Cursor = Cursors.Hand;
            dtpFrom.Font = new Font("Segoe UI", 8.25F);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(149, 9);
            dtpFrom.Margin = new Padding(4, 3, 4, 3);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(106, 22);
            dtpFrom.TabIndex = 0;
            // 
            // dtpTo
            // 
            dtpTo.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpTo.Cursor = Cursors.Hand;
            dtpTo.Font = new Font("Segoe UI", 8.25F);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(13, 9);
            dtpTo.Margin = new Padding(4, 3, 4, 3);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(106, 22);
            dtpTo.TabIndex = 0;
            // 
            // pnlExpense
            // 
            pnlExpense.BackColor = Color.Cyan;
            pnlExpense.Controls.Add(lblIncome);
            pnlExpense.Controls.Add(label1);
            pnlExpense.Font = new Font("Shabnam", 11.25F);
            pnlExpense.ForeColor = Color.Black;
            pnlExpense.Location = new Point(253, 414);
            pnlExpense.Margin = new Padding(4, 3, 4, 3);
            pnlExpense.Name = "pnlExpense";
            pnlExpense.Size = new Size(245, 42);
            pnlExpense.TabIndex = 7;
            // 
            // pnlIncome
            // 
            pnlIncome.BackColor = Color.FromArgb(255, 128, 128);
            pnlIncome.Controls.Add(lblExpense);
            pnlIncome.Controls.Add(label2);
            pnlIncome.Font = new Font("Shabnam", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlIncome.ForeColor = Color.Black;
            pnlIncome.Location = new Point(504, 414);
            pnlIncome.Margin = new Padding(4, 3, 4, 3);
            pnlIncome.Name = "pnlIncome";
            pnlIncome.Size = new Size(240, 42);
            pnlIncome.TabIndex = 8;
            // 
            // pnlBalance
            // 
            pnlBalance.BackColor = Color.FromArgb(224, 224, 224);
            pnlBalance.Controls.Add(label3);
            pnlBalance.Controls.Add(lblBalance);
            pnlBalance.Font = new Font("Shabnam", 11.25F);
            pnlBalance.Location = new Point(5, 414);
            pnlBalance.Margin = new Padding(4, 3, 4, 3);
            pnlBalance.Name = "pnlBalance";
            pnlBalance.Size = new Size(240, 42);
            pnlBalance.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(749, 513);
            Controls.Add(pnlBalance);
            Controls.Add(pnlIncome);
            Controls.Add(pnlExpense);
            Controls.Add(filterPanel);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "مدیر مالی";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            pnlExpense.ResumeLayout(false);
            pnlExpense.PerformLayout();
            pnlIncome.ResumeLayout(false);
            pnlIncome.PerformLayout();
            pnlBalance.ResumeLayout(false);
            pnlBalance.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblBalance;
        private Label lblIncome;
        private Label lblExpense;
        private Button btnAdd;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnLogout;
        private Panel panel1;
        private Label lblUsername;
        private Label label4;
        private Panel panel2;
        private Button btnEdit;
        private Label lblTodayDate;
        private Label label5;
        private Panel filterPanel;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private ComboBox cmbFilterCategory;
        private Button btnClearFilter;
        private Button btnFilter;
        private ComboBox cmbFilterType;
        private Label label7;
        private Label label6;
        private Panel pnlExpense;
        private Panel pnlIncome;
        private Panel pnlBalance;
        private Button bthCharts;
    }
}