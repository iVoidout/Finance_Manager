namespace Finance_Tracker.Forms
{
    partial class RegisterForm
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
            btnRegister = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtConfirm = new TextBox();
            cmbRole = new ComboBox();
            label4 = new Label();
            cmbDepartment = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Cyan;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Shabnam", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.Black;
            btnRegister.Location = new Point(48, 231);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(345, 28);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "ثبت نام";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(48, 108);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(169, 23);
            txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(48, 48);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(169, 23);
            txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(48, 87);
            label2.Name = "label2";
            label2.Size = new Size(46, 18);
            label2.TabIndex = 3;
            label2.Text = "گذرواژه";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 27);
            label1.Name = "label1";
            label1.Size = new Size(60, 18);
            label1.TabIndex = 4;
            label1.Text = "نام کاربری";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(224, 87);
            label3.Name = "label3";
            label3.Size = new Size(77, 18);
            label3.TabIndex = 3;
            label3.Text = "تایید گذرواژه";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(224, 108);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.PasswordChar = '*';
            txtConfirm.Size = new Size(169, 23);
            txtConfirm.TabIndex = 3;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(48, 174);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(169, 23);
            cmbRole.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(48, 149);
            label4.Name = "label4";
            label4.Size = new Size(54, 18);
            label4.TabIndex = 3;
            label4.Text = "دسترسی";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(224, 174);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(169, 23);
            cmbDepartment.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Shabnam", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(224, 149);
            label5.Name = "label5";
            label5.Size = new Size(50, 18);
            label5.TabIndex = 3;
            label5.Text = "دپارتمان";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 310);
            Controls.Add(cmbDepartment);
            Controls.Add(cmbRole);
            Controls.Add(btnRegister);
            Controls.Add(txtConfirm);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ثبت نام";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegister;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtConfirm;
        private ComboBox cmbRole;
        private Label label4;
        private ComboBox cmbDepartment;
        private Label label5;
    }
}