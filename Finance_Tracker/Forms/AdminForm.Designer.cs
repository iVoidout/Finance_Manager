namespace Finance_Tracker.Forms
{
    partial class AdminForm
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
            btnCategories = new Finance_Tracker.Controls.PrimaryButton();
            btnBudget = new Finance_Tracker.Controls.PrimaryButton();
            btnApproval = new Finance_Tracker.Controls.PrimaryButton();
            btnDepartments = new Finance_Tracker.Controls.PrimaryButton();
            SuspendLayout();
            // 
            // btnCategories
            // 
            btnCategories.BackColor = Color.Cyan;
            btnCategories.FlatAppearance.BorderSize = 0;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Shabnam", 9.75F);
            btnCategories.ForeColor = Color.Black;
            btnCategories.Location = new Point(10, 144);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(230, 38);
            btnCategories.TabIndex = 0;
            btnCategories.TabStop = false;
            btnCategories.Text = "دسته بندی ها";
            btnCategories.UseVisualStyleBackColor = false;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnBudget
            // 
            btnBudget.BackColor = Color.Cyan;
            btnBudget.FlatAppearance.BorderSize = 0;
            btnBudget.FlatStyle = FlatStyle.Flat;
            btnBudget.Font = new Font("Shabnam", 9.75F);
            btnBudget.ForeColor = Color.Black;
            btnBudget.Location = new Point(12, 12);
            btnBudget.Name = "btnBudget";
            btnBudget.Size = new Size(230, 38);
            btnBudget.TabIndex = 1;
            btnBudget.TabStop = false;
            btnBudget.Text = "تنظیم بودجه";
            btnBudget.UseVisualStyleBackColor = false;
            btnBudget.Click += btnBudget_Click;
            // 
            // btnApproval
            // 
            btnApproval.BackColor = Color.Cyan;
            btnApproval.FlatAppearance.BorderSize = 0;
            btnApproval.FlatStyle = FlatStyle.Flat;
            btnApproval.Font = new Font("Shabnam", 9.75F);
            btnApproval.ForeColor = Color.Black;
            btnApproval.Location = new Point(12, 56);
            btnApproval.Name = "btnApproval";
            btnApproval.Size = new Size(230, 38);
            btnApproval.TabIndex = 2;
            btnApproval.TabStop = false;
            btnApproval.Text = "تایید تراکنش";
            btnApproval.UseVisualStyleBackColor = false;
            btnApproval.Click += btnApproval_Click;
            // 
            // btnDepartments
            // 
            btnDepartments.BackColor = Color.Cyan;
            btnDepartments.FlatAppearance.BorderSize = 0;
            btnDepartments.FlatStyle = FlatStyle.Flat;
            btnDepartments.Font = new Font("Shabnam", 9.75F);
            btnDepartments.ForeColor = Color.Black;
            btnDepartments.Location = new Point(12, 100);
            btnDepartments.Name = "btnDepartments";
            btnDepartments.Size = new Size(230, 38);
            btnDepartments.TabIndex = 3;
            btnDepartments.TabStop = false;
            btnDepartments.Text = "دپارتمان ها";
            btnDepartments.UseVisualStyleBackColor = false;
            btnDepartments.Click += btnDepartments_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 194);
            Controls.Add(btnDepartments);
            Controls.Add(btnApproval);
            Controls.Add(btnBudget);
            Controls.Add(btnCategories);
            MaximizeBox = false;
            Name = "AdminForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "مدیریت";
            ResumeLayout(false);
        }

        #endregion

        private Controls.PrimaryButton btnCategories;
        private Controls.PrimaryButton btnBudget;
        private Controls.PrimaryButton btnApproval;
        private Controls.PrimaryButton btnDepartments;
    }
}