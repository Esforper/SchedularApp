﻿namespace Faculty_Course_scheduler
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.academianPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            this.academianPanel.Location = new System.Drawing.Point(10, 10);
            this.academianPanel.Name = "academianPanel";
            this.academianPanel.Padding = new System.Windows.Forms.Padding(10);
            this.academianPanel.Size = new System.Drawing.Size(1389, 671);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(1409, 691);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sınıflar";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel academianPanel;
        private System.Windows.Forms.Button defaultBtn;
    }
}
