namespace Finance_Tracker.Forms
{
    partial class AddTransactionForm
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
            label4 = new Label();
            txtAmount = new TextBox();
            label1 = new Label();
            txtDescription = new TextBox();
            cmbCategory = new ComboBox();
            label2 = new Label();
            dtpDate = new DateTimePicker();
            label3 = new Label();
            rbIncome = new RadioButton();
            rbExpense = new RadioButton();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 14);
            label4.Name = "label4";
            label4.Size = new Size(73, 18);
            label4.TabIndex = 0;
            label4.Text = "مبلغ (تومان)";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(26, 35);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(206, 23);
            txtAmount.TabIndex = 1;
            txtAmount.TextChanged += txtAmount_TextChanged;
            txtAmount.KeyPress += txtAmount_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 65);
            label1.Name = "label1";
            label1.Size = new Size(60, 18);
            label1.TabIndex = 0;
            label1.Text = "توضیحات";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(26, 86);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(206, 23);
            txtDescription.TabIndex = 2;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(26, 137);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(206, 23);
            cmbCategory.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 116);
            label2.Name = "label2";
            label2.Size = new Size(67, 18);
            label2.TabIndex = 0;
            label2.Text = "دسته بندی";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(26, 191);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(206, 23);
            dtpDate.TabIndex = 4;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 170);
            label3.Name = "label3";
            label3.Size = new Size(35, 18);
            label3.TabIndex = 0;
            label3.Text = "تاریخ";
            // 
            // rbIncome
            // 
            rbIncome.AutoSize = true;
            rbIncome.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbIncome.Location = new Point(69, 229);
            rbIncome.Name = "rbIncome";
            rbIncome.Size = new Size(53, 22);
            rbIncome.TabIndex = 6;
            rbIncome.TabStop = true;
            rbIncome.Text = "درآمد";
            rbIncome.UseVisualStyleBackColor = true;
            rbIncome.CheckedChanged += rbIncome_CheckedChanged;
            // 
            // rbExpense
            // 
            rbExpense.AutoSize = true;
            rbExpense.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbExpense.Location = new Point(128, 229);
            rbExpense.Name = "rbExpense";
            rbExpense.Size = new Size(57, 22);
            rbExpense.TabIndex = 5;
            rbExpense.TabStop = true;
            rbExpense.Text = "هزینه";
            rbExpense.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Cyan;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Shabnam", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(26, 263);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(206, 34);
            btnSave.TabIndex = 7;
            btnSave.Text = "دخیره";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Shabnam", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(72, 311);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(117, 26);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "انصراف";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddTransactionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 354);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(rbExpense);
            Controls.Add(rbIncome);
            Controls.Add(dtpDate);
            Controls.Add(cmbCategory);
            Controls.Add(txtDescription);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAmount);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTransactionForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافه تراکنش";
            Load += addTransactionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox txtAmount;
        private Label label1;
        private TextBox txtDescription;
        private ComboBox cmbCategory;
        private Label label2;
        private DateTimePicker dtpDate;
        private Label label3;
        private RadioButton rbIncome;
        private RadioButton rbExpense;
        private Button btnSave;
        private Button btnCancel;
    }
}