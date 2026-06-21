namespace Finance_Tracker.Forms
{
    partial class DepartmentForm
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
            lstDepartments = new ListBox();
            txtNewDepartment = new TextBox();
            btnAddDepartment = new Finance_Tracker.Controls.PrimaryButton();
            btnDeleteDepartment = new Finance_Tracker.Controls.SecondaryButton();
            btnClose = new Finance_Tracker.Controls.PrimaryButton();
            SuspendLayout();
            // 
            // lstDepartments
            // 
            lstDepartments.FormattingEnabled = true;
            lstDepartments.ItemHeight = 15;
            lstDepartments.Location = new Point(12, 12);
            lstDepartments.Name = "lstDepartments";
            lstDepartments.Size = new Size(180, 154);
            lstDepartments.TabIndex = 0;
            // 
            // txtNewDepartment
            // 
            txtNewDepartment.Location = new Point(12, 171);
            txtNewDepartment.Name = "txtNewDepartment";
            txtNewDepartment.Size = new Size(180, 23);
            txtNewDepartment.TabIndex = 1;
            // 
            // btnAddDepartment
            // 
            btnAddDepartment.BackColor = Color.Cyan;
            btnAddDepartment.FlatAppearance.BorderSize = 0;
            btnAddDepartment.FlatStyle = FlatStyle.Flat;
            btnAddDepartment.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddDepartment.ForeColor = Color.Black;
            btnAddDepartment.Location = new Point(12, 200);
            btnAddDepartment.Name = "btnAddDepartment";
            btnAddDepartment.Size = new Size(75, 23);
            btnAddDepartment.TabIndex = 3;
            btnAddDepartment.TabStop = false;
            btnAddDepartment.Text = "افزودن";
            btnAddDepartment.UseVisualStyleBackColor = false;
            btnAddDepartment.Click += btnAddCategory_Click;
            // 
            // btnDeleteDepartment
            // 
            btnDeleteDepartment.BackColor = Color.FromArgb(255, 128, 128);
            btnDeleteDepartment.FlatAppearance.BorderSize = 0;
            btnDeleteDepartment.FlatStyle = FlatStyle.Flat;
            btnDeleteDepartment.Font = new Font("Shabnam", 9.75F);
            btnDeleteDepartment.ForeColor = Color.Black;
            btnDeleteDepartment.Location = new Point(115, 200);
            btnDeleteDepartment.Name = "btnDeleteDepartment";
            btnDeleteDepartment.Size = new Size(75, 23);
            btnDeleteDepartment.TabIndex = 4;
            btnDeleteDepartment.TabStop = false;
            btnDeleteDepartment.Text = "حذف";
            btnDeleteDepartment.UseVisualStyleBackColor = false;
            btnDeleteDepartment.Click += btnDeleteCategory_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Cyan;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Shabnam", 9.75F);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(64, 241);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.TabStop = false;
            btnClose.Text = "بستن";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // DepartmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(202, 276);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteDepartment);
            Controls.Add(btnAddDepartment);
            Controls.Add(txtNewDepartment);
            Controls.Add(lstDepartments);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DepartmentForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "دپارتمان ها";
            Load += SettingsFrom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstDepartments;
        private TextBox txtNewDepartment;
        private Controls.PrimaryButton btnAddDepartment;
        private Controls.SecondaryButton btnDeleteDepartment;
        private Controls.PrimaryButton btnClose;
    }
}