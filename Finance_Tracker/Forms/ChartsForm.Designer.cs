namespace Finance_Tracker.Forms
{
    partial class ChartsForm
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
            webView1 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView1).BeginInit();
            SuspendLayout();
            // 
            // webView1
            // 
            webView1.AllowExternalDrop = true;
            webView1.CreationProperties = null;
            webView1.DefaultBackgroundColor = Color.White;
            webView1.Dock = DockStyle.Fill;
            webView1.Location = new Point(0, 0);
            webView1.Name = "webView1";
            webView1.Size = new Size(634, 471);
            webView1.TabIndex = 0;
            webView1.ZoomFactor = 1D;
            // 
            // ChartsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 471);
            Controls.Add(webView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChartsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "نمودار ها";
            Load += ChartsForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView1;
    }
}