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
            tabControl1 = new TabControl();
            tabPie = new TabPage();
            tabBars = new TabPage();
            webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPie.SuspendLayout();
            tabBars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).BeginInit();
            SuspendLayout();
            // 
            // webView1
            // 
            webView1.AllowExternalDrop = true;
            webView1.CreationProperties = null;
            webView1.DefaultBackgroundColor = Color.White;
            webView1.Dock = DockStyle.Fill;
            webView1.Location = new Point(3, 3);
            webView1.Name = "webView1";
            webView1.Size = new Size(620, 377);
            webView1.TabIndex = 0;
            webView1.ZoomFactor = 1D;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPie);
            tabControl1.Controls.Add(tabBars);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(634, 411);
            tabControl1.TabIndex = 1;
            // 
            // tabPie
            // 
            tabPie.Controls.Add(webView1);
            tabPie.Location = new Point(4, 24);
            tabPie.Name = "tabPie";
            tabPie.Padding = new Padding(3);
            tabPie.Size = new Size(626, 383);
            tabPie.TabIndex = 0;
            tabPie.Text = "نمودار هزینه ها بر اساس دسته بندی";
            tabPie.UseVisualStyleBackColor = true;
            // 
            // tabBars
            // 
            tabBars.Controls.Add(webView22);
            tabBars.Location = new Point(4, 24);
            tabBars.Name = "tabBars";
            tabBars.Padding = new Padding(3);
            tabBars.Size = new Size(626, 383);
            tabBars.TabIndex = 1;
            tabBars.Text = "در آمد و هزینه ها";
            tabBars.UseVisualStyleBackColor = true;
            // 
            // webView22
            // 
            webView22.AllowExternalDrop = true;
            webView22.CreationProperties = null;
            webView22.DefaultBackgroundColor = Color.White;
            webView22.Dock = DockStyle.Fill;
            webView22.Location = new Point(3, 3);
            webView22.Name = "webView22";
            webView22.Size = new Size(620, 377);
            webView22.TabIndex = 0;
            webView22.ZoomFactor = 1D;
            // 
            // ChartsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 411);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChartsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ChartsForm";
            Load += ChartsForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPie.ResumeLayout(false);
            tabBars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView22).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView1;
        private TabControl tabControl1;
        private TabPage tabPie;
        private TabPage tabBars;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView22;
    }
}