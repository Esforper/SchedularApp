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
            this.makeScheduleBtn = new FontAwesome.Sharp.IconButton();
            this.ıconButton3 = new FontAwesome.Sharp.IconButton();
            this.infoShowBtn = new FontAwesome.Sharp.IconButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.infoBtn);
            this.flowLayoutPanel1.Controls.Add(this.makeScheduleBtn);
            this.flowLayoutPanel1.Controls.Add(this.ıconButton3);
            this.flowLayoutPanel1.Controls.Add(this.infoShowBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(233, 756);
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
            this.infoBtn.FlatAppearance.BorderSize = 0;
            this.infoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.infoBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.infoBtn.IconChar = FontAwesome.Sharp.IconChar.Inbox;
            this.infoBtn.IconColor = System.Drawing.Color.White;
            this.infoBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.infoBtn.Location = new System.Drawing.Point(0, 115);
            this.infoBtn.Margin = new System.Windows.Forms.Padding(0);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(233, 82);
            this.infoBtn.TabIndex = 1;
            this.infoBtn.Text = "Bilgi Girişi";
            this.infoBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.ıconButton1_Click);
            // 
            // makeScheduleBtn
            // 
            this.makeScheduleBtn.FlatAppearance.BorderSize = 0;
            this.makeScheduleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeScheduleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.makeScheduleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.makeScheduleBtn.IconChar = FontAwesome.Sharp.IconChar.ProjectDiagram;
            this.makeScheduleBtn.IconColor = System.Drawing.Color.White;
            this.makeScheduleBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.makeScheduleBtn.Location = new System.Drawing.Point(0, 197);
            this.makeScheduleBtn.Margin = new System.Windows.Forms.Padding(0);
            this.makeScheduleBtn.Name = "makeScheduleBtn";
            this.makeScheduleBtn.Size = new System.Drawing.Size(233, 82);
            this.makeScheduleBtn.TabIndex = 2;
            this.makeScheduleBtn.Text = "Ders Programı Oluştur.";
            this.makeScheduleBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.makeScheduleBtn.UseVisualStyleBackColor = true;
            this.makeScheduleBtn.Click += new System.EventHandler(this.makeScheduleBtn_Click);
            // 
            // ıconButton3
            // 
            this.ıconButton3.FlatAppearance.BorderSize = 0;
            this.ıconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButton3.ForeColor = System.Drawing.SystemColors.Control;
            this.ıconButton3.IconChar = FontAwesome.Sharp.IconChar.ProjectDiagram;
            this.ıconButton3.IconColor = System.Drawing.Color.White;
            this.ıconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton3.Location = new System.Drawing.Point(0, 279);
            this.ıconButton3.Margin = new System.Windows.Forms.Padding(0);
            this.ıconButton3.Name = "ıconButton3";
            this.ıconButton3.Size = new System.Drawing.Size(233, 82);
            this.ıconButton3.TabIndex = 3;
            this.ıconButton3.Text = "Sınav Programı Oluştur.";
            this.ıconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButton3.UseVisualStyleBackColor = true;
            // 
            // infoShowBtn
            // 
            this.infoShowBtn.FlatAppearance.BorderSize = 0;
            this.infoShowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoShowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.infoShowBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.infoShowBtn.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.infoShowBtn.IconColor = System.Drawing.Color.White;
            this.infoShowBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.infoShowBtn.Location = new System.Drawing.Point(0, 361);
            this.infoShowBtn.Margin = new System.Windows.Forms.Padding(0);
            this.infoShowBtn.Name = "infoShowBtn";
            this.infoShowBtn.Size = new System.Drawing.Size(233, 82);
            this.infoShowBtn.TabIndex = 4;
            this.infoShowBtn.Text = "Bilgi görüntüle";
            this.infoShowBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.infoShowBtn.UseVisualStyleBackColor = true;
            this.infoShowBtn.Click += new System.EventHandler(this.infoShowBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(233, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1328, 756);
            this.mainPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(566, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "Faculty Course Schedular";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(0, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(566, 68);
            this.label2.TabIndex = 1;
            this.label2.Text = "Uygulamasına Hoş Geldiniz";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(400, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 138);
            this.panel2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1561, 756);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private FontAwesome.Sharp.IconButton infoBtn;
		private FontAwesome.Sharp.IconButton makeScheduleBtn;
		private FontAwesome.Sharp.IconButton ıconButton3;
		private System.Windows.Forms.Panel mainPanel;
        private FontAwesome.Sharp.IconButton infoShowBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}

