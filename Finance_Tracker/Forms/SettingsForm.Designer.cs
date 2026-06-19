namespace Finance_Tracker.Forms
{
    partial class SettingsForm
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
            txtNewCategory.Location = new Point(12, 171);
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
            btnAddCategory.Location = new Point(12, 200);
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
            btnDeleteCategory.Location = new Point(115, 200);
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
            btnClose.Location = new Point(62, 284);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.TabStop = false;
            btnClose.Text = "بستن";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(202, 338);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteCategory);
            Controls.Add(btnAddCategory);
            Controls.Add(txtNewCategory);
            Controls.Add(lstCategories);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "تنظیمات";
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
    }
}