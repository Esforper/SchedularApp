namespace Faculty_Course_scheduler
{
	partial class Form1
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

		#region Windows Form Designer üretilen kod

		/// <summary>
		/// Tasarımcı desteği için gerekli metot - bu metodun 
		///içeriğini kod düzenleyici ile değiştirmeyin.
		/// </summary>
		private void InitializeComponent()
		{
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoBtn = new FontAwesome.Sharp.IconButton();
            this.ıconButton2 = new FontAwesome.Sharp.IconButton();
            this.ıconButton3 = new FontAwesome.Sharp.IconButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.infoShowBtn = new FontAwesome.Sharp.IconButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.infoBtn);
            this.flowLayoutPanel1.Controls.Add(this.ıconButton2);
            this.flowLayoutPanel1.Controls.Add(this.ıconButton3);
            this.flowLayoutPanel1.Controls.Add(this.infoShowBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(233, 716);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 115);
            this.panel1.TabIndex = 0;
            // 
            // infoBtn
            // 
            this.infoBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.infoBtn.IconColor = System.Drawing.Color.Black;
            this.infoBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.infoBtn.Location = new System.Drawing.Point(0, 115);
            this.infoBtn.Margin = new System.Windows.Forms.Padding(0);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(233, 82);
            this.infoBtn.TabIndex = 1;
            this.infoBtn.Text = "Bilgi Girişi";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.ıconButton1_Click);
            // 
            // ıconButton2
            // 
            this.ıconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ıconButton2.IconColor = System.Drawing.Color.Black;
            this.ıconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton2.Location = new System.Drawing.Point(0, 197);
            this.ıconButton2.Margin = new System.Windows.Forms.Padding(0);
            this.ıconButton2.Name = "ıconButton2";
            this.ıconButton2.Size = new System.Drawing.Size(233, 82);
            this.ıconButton2.TabIndex = 2;
            this.ıconButton2.Text = "Ders Programı Oluştur.";
            this.ıconButton2.UseVisualStyleBackColor = true;
            // 
            // ıconButton3
            // 
            this.ıconButton3.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ıconButton3.IconColor = System.Drawing.Color.Black;
            this.ıconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton3.Location = new System.Drawing.Point(0, 279);
            this.ıconButton3.Margin = new System.Windows.Forms.Padding(0);
            this.ıconButton3.Name = "ıconButton3";
            this.ıconButton3.Size = new System.Drawing.Size(233, 82);
            this.ıconButton3.TabIndex = 3;
            this.ıconButton3.Text = "Sınav Programı Oluştur.";
            this.ıconButton3.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(233, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1284, 716);
            this.mainPanel.TabIndex = 1;
            // 
            // infoShowBtn
            // 
            this.infoShowBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.infoShowBtn.IconColor = System.Drawing.Color.Black;
            this.infoShowBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.infoShowBtn.Location = new System.Drawing.Point(0, 361);
            this.infoShowBtn.Margin = new System.Windows.Forms.Padding(0);
            this.infoShowBtn.Name = "infoShowBtn";
            this.infoShowBtn.Size = new System.Drawing.Size(233, 82);
            this.infoShowBtn.TabIndex = 4;
            this.infoShowBtn.Text = "Bilgi görüntüle";
            this.infoShowBtn.UseVisualStyleBackColor = true;
            this.infoShowBtn.Click += new System.EventHandler(this.infoShowBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 716);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private FontAwesome.Sharp.IconButton infoBtn;
		private FontAwesome.Sharp.IconButton ıconButton2;
		private FontAwesome.Sharp.IconButton ıconButton3;
		private System.Windows.Forms.Panel mainPanel;
        private FontAwesome.Sharp.IconButton infoShowBtn;
    }
}

