namespace Finance_Tracker.Forms
{
    partial class ApprovalForm
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
            dgvPending = new DataGridView();
            btnApprove = new Finance_Tracker.Controls.PrimaryButton();
            btnClose = new Finance_Tracker.Controls.PrimaryButton();
            btnReject = new Finance_Tracker.Controls.SecondaryButton();
            ((System.ComponentModel.ISupportInitialize)dgvPending).BeginInit();
            SuspendLayout();
            // 
            // dgvPending
            // 
            dgvPending.AllowUserToAddRows = false;
            dgvPending.AllowUserToDeleteRows = false;
            dgvPending.AllowUserToOrderColumns = true;
            dgvPending.AllowUserToResizeColumns = false;
            dgvPending.AllowUserToResizeRows = false;
            dgvPending.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Shabnam", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPending.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPending.GridColor = Color.White;
            dgvPending.Location = new Point(12, 21);
            dgvPending.Name = "dgvPending";
            dgvPending.ReadOnly = true;
            dgvPending.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = Color.Cyan;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvPending.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPending.Size = new Size(535, 269);
            dgvPending.TabIndex = 0;
            dgvPending.CellContentClick += dgvPending_CellContentClick;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.Cyan;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Shabnam", 9.75F);
            btnApprove.ForeColor = Color.Black;
            btnApprove.Location = new Point(12, 296);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(75, 23);
            btnApprove.TabIndex = 1;
            btnApprove.TabStop = false;
            btnApprove.Text = "تایید";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Cyan;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Shabnam", 9.75F);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(472, 296);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 2;
            btnClose.TabStop = false;
            btnClose.Text = "بستن";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.FromArgb(255, 128, 128);
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Shabnam", 9.75F);
            btnReject.ForeColor = Color.Black;
            btnReject.Location = new Point(93, 296);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(75, 23);
            btnReject.TabIndex = 3;
            btnReject.TabStop = false;
            btnReject.Text = "رد";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // ApprovalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 334);
            Controls.Add(btnReject);
            Controls.Add(btnClose);
            Controls.Add(btnApprove);
            Controls.Add(dgvPending);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ApprovalForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "تایید تراکنش ها";
            Load += ApprovalForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPending).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPending;
        private Controls.PrimaryButton btnApprove;
        private Controls.PrimaryButton btnClose;
        private Controls.SecondaryButton btnReject;
    }
}