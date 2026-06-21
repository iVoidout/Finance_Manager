namespace Finance_Tracker.Forms
{
    partial class CategoriesForm
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
            lstCategories = new ListBox();
            txtNewCategory = new TextBox();
            btnAddCategory = new Finance_Tracker.Controls.PrimaryButton();
            btnDeleteCategory = new Finance_Tracker.Controls.SecondaryButton();
            btnClose = new Finance_Tracker.Controls.PrimaryButton();
            rbCatIncome = new RadioButton();
            rbCatExpense = new RadioButton();
            SuspendLayout();
            // 
            // lstCategories
            // 
            lstCategories.FormattingEnabled = true;
            lstCategories.ItemHeight = 15;
            lstCategories.Location = new Point(12, 12);
            lstCategories.Name = "lstCategories";
            lstCategories.Size = new Size(180, 154);
            lstCategories.TabIndex = 0;
            // 
            // txtNewCategory
            // 
            txtNewCategory.Location = new Point(10, 207);
            txtNewCategory.Name = "txtNewCategory";
            txtNewCategory.Size = new Size(180, 23);
            txtNewCategory.TabIndex = 1;
            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = Color.Cyan;
            btnAddCategory.FlatAppearance.BorderSize = 0;
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddCategory.ForeColor = Color.Black;
            btnAddCategory.Location = new Point(10, 236);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(75, 23);
            btnAddCategory.TabIndex = 3;
            btnAddCategory.TabStop = false;
            btnAddCategory.Text = "افزودن";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.BackColor = Color.FromArgb(255, 128, 128);
            btnDeleteCategory.FlatAppearance.BorderSize = 0;
            btnDeleteCategory.FlatStyle = FlatStyle.Flat;
            btnDeleteCategory.Font = new Font("Shabnam", 9.75F);
            btnDeleteCategory.ForeColor = Color.Black;
            btnDeleteCategory.Location = new Point(115, 236);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(75, 23);
            btnDeleteCategory.TabIndex = 4;
            btnDeleteCategory.TabStop = false;
            btnDeleteCategory.Text = "حذف";
            btnDeleteCategory.UseVisualStyleBackColor = false;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Cyan;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Shabnam", 9.75F);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(64, 273);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.TabStop = false;
            btnClose.Text = "بستن";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // rbCatIncome
            // 
            rbCatIncome.AutoSize = true;
            rbCatIncome.Location = new Point(36, 178);
            rbCatIncome.Name = "rbCatIncome";
            rbCatIncome.Size = new Size(51, 19);
            rbCatIncome.TabIndex = 6;
            rbCatIncome.TabStop = true;
            rbCatIncome.Text = "درآمد";
            rbCatIncome.UseVisualStyleBackColor = true;
            rbCatIncome.CheckedChanged += rbCatIncome_CheckedChanged;
            // 
            // rbCatExpense
            // 
            rbCatExpense.AutoSize = true;
            rbCatExpense.Location = new Point(117, 178);
            rbCatExpense.Name = "rbCatExpense";
            rbCatExpense.Size = new Size(53, 19);
            rbCatExpense.TabIndex = 7;
            rbCatExpense.TabStop = true;
            rbCatExpense.Text = "هزینه";
            rbCatExpense.UseVisualStyleBackColor = true;
            rbCatExpense.CheckedChanged += rbCatExpense_CheckedChanged;
            // 
            // CategoriesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(202, 311);
            Controls.Add(rbCatExpense);
            Controls.Add(rbCatIncome);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteCategory);
            Controls.Add(btnAddCategory);
            Controls.Add(txtNewCategory);
            Controls.Add(lstCategories);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoriesForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "دسته بندی ها";
            Load += SettingsFrom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstCategories;
        private TextBox txtNewCategory;
        private Controls.PrimaryButton btnAddCategory;
        private Controls.SecondaryButton btnDeleteCategory;
        private Controls.PrimaryButton btnClose;
        private RadioButton rbCatIncome;
        private RadioButton rbCatExpense;
    }
}