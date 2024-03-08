namespace Faculty_Course_scheduler
{
    partial class infoShowControl
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.academianPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.defaultBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.classPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.PeriodPage = new System.Windows.Forms.TabPage();
            this.sectionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sectionDefaultBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.academianPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.classPanel.SuspendLayout();
            this.PeriodPage.SuspendLayout();
            this.sectionPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.PeriodPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1417, 724);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.academianPanel);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(1409, 691);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Akademisyenler";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // academianPanel
            // 
            this.academianPanel.Controls.Add(this.defaultBtn);
            this.academianPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.academianPanel.Location = new System.Drawing.Point(10, 51);
            this.academianPanel.Name = "academianPanel";
            this.academianPanel.Padding = new System.Windows.Forms.Padding(10);
            this.academianPanel.Size = new System.Drawing.Size(1389, 630);
            this.academianPanel.TabIndex = 0;
            // 
            // defaultBtn
            // 
            this.defaultBtn.Location = new System.Drawing.Point(20, 20);
            this.defaultBtn.Margin = new System.Windows.Forms.Padding(10);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(202, 47);
            this.defaultBtn.TabIndex = 2;
            this.defaultBtn.Text = "button1";
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.classPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(1409, 691);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sınıflar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // classPanel
            // 
            this.classPanel.Controls.Add(this.button1);
            this.classPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classPanel.Location = new System.Drawing.Point(10, 10);
            this.classPanel.Name = "classPanel";
            this.classPanel.Padding = new System.Windows.Forms.Padding(10);
            this.classPanel.Size = new System.Drawing.Size(1389, 671);
            this.classPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 20);
            this.button1.Margin = new System.Windows.Forms.Padding(10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // PeriodPage
            // 
            this.PeriodPage.Controls.Add(this.sectionPanel);
            this.PeriodPage.Location = new System.Drawing.Point(4, 29);
            this.PeriodPage.Name = "PeriodPage";
            this.PeriodPage.Padding = new System.Windows.Forms.Padding(3);
            this.PeriodPage.Size = new System.Drawing.Size(1409, 691);
            this.PeriodPage.TabIndex = 2;
            this.PeriodPage.Text = "Bölüm - Sınıflar";
            this.PeriodPage.UseVisualStyleBackColor = true;
            // 
            // sectionPanel
            // 
            this.sectionPanel.Controls.Add(this.sectionDefaultBtn);
            this.sectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionPanel.Location = new System.Drawing.Point(3, 3);
            this.sectionPanel.Name = "sectionPanel";
            this.sectionPanel.Padding = new System.Windows.Forms.Padding(10);
            this.sectionPanel.Size = new System.Drawing.Size(1403, 685);
            this.sectionPanel.TabIndex = 2;
            // 
            // sectionDefaultBtn
            // 
            this.sectionDefaultBtn.Location = new System.Drawing.Point(20, 20);
            this.sectionDefaultBtn.Margin = new System.Windows.Forms.Padding(10);
            this.sectionDefaultBtn.Name = "sectionDefaultBtn";
            this.sectionDefaultBtn.Size = new System.Drawing.Size(1364, 47);
            this.sectionDefaultBtn.TabIndex = 2;
            this.sectionDefaultBtn.Text = "button2";
            this.sectionDefaultBtn.UseVisualStyleBackColor = true;
            this.sectionDefaultBtn.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.filterComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1389, 41);
            this.panel1.TabIndex = 3;
            // 
            // filterComboBox
            // 
            this.filterComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(1157, 7);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(220, 28);
            this.filterComboBox.TabIndex = 0;
            // 
            // infoShowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "infoShowControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1437, 744);
            this.Load += new System.EventHandler(this.infoShowControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.academianPanel.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.classPanel.ResumeLayout(false);
            this.PeriodPage.ResumeLayout(false);
            this.sectionPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel academianPanel;
        private System.Windows.Forms.Button defaultBtn;
        private System.Windows.Forms.FlowLayoutPanel classPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage PeriodPage;
        private System.Windows.Forms.FlowLayoutPanel sectionPanel;
        private System.Windows.Forms.Button sectionDefaultBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox filterComboBox;
    }
}
