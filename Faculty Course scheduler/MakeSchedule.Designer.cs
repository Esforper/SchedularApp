namespace Faculty_Course_scheduler
{
    partial class MakeSchedule
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.facultiesComboBox = new System.Windows.Forms.ComboBox();
            this.FacultyClassNumberComboBox = new System.Windows.Forms.ComboBox();
            this.springAutumnComboBox = new System.Windows.Forms.ComboBox();
            this.labelFacultyClass = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lessonsListBox = new System.Windows.Forms.ListBox();
            this.makeScheduleBtn = new System.Windows.Forms.Button();
            this.findFacultyBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bölümü Seçiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sınıfı Seçiniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(717, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dönem Seçiniz:";
            // 
            // facultiesComboBox
            // 
            this.facultiesComboBox.FormattingEnabled = true;
            this.facultiesComboBox.Location = new System.Drawing.Point(158, 29);
            this.facultiesComboBox.Name = "facultiesComboBox";
            this.facultiesComboBox.Size = new System.Drawing.Size(172, 28);
            this.facultiesComboBox.TabIndex = 45;
            this.facultiesComboBox.SelectedIndexChanged += new System.EventHandler(this.facultiesComboBox_SelectedIndexChanged);
            this.facultiesComboBox.SelectedValueChanged += new System.EventHandler(this.facultiesComboBox_SelectedValueChanged);
            // 
            // FacultyClassNumberComboBox
            // 
            this.FacultyClassNumberComboBox.FormattingEnabled = true;
            this.FacultyClassNumberComboBox.Location = new System.Drawing.Point(489, 29);
            this.FacultyClassNumberComboBox.Name = "FacultyClassNumberComboBox";
            this.FacultyClassNumberComboBox.Size = new System.Drawing.Size(172, 28);
            this.FacultyClassNumberComboBox.TabIndex = 46;
            // 
            // springAutumnComboBox
            // 
            this.springAutumnComboBox.FormattingEnabled = true;
            this.springAutumnComboBox.Items.AddRange(new object[] {
            "güz dönemi",
            "bahar dönemi"});
            this.springAutumnComboBox.Location = new System.Drawing.Point(851, 29);
            this.springAutumnComboBox.Name = "springAutumnComboBox";
            this.springAutumnComboBox.Size = new System.Drawing.Size(172, 28);
            this.springAutumnComboBox.TabIndex = 47;
            this.springAutumnComboBox.SelectedIndexChanged += new System.EventHandler(this.springAutumnComboBox_SelectedIndexChanged);
            // 
            // labelFacultyClass
            // 
            this.labelFacultyClass.AutoSize = true;
            this.labelFacultyClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelFacultyClass.Location = new System.Drawing.Point(75, 102);
            this.labelFacultyClass.Name = "labelFacultyClass";
            this.labelFacultyClass.Size = new System.Drawing.Size(264, 26);
            this.labelFacultyClass.TabIndex = 48;
            this.labelFacultyClass.Text = "<Fakülte : Sınıfı : Dönem>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(75, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 49;
            this.label5.Text = "Dersler";
            // 
            // lessonsListBox
            // 
            this.lessonsListBox.BackColor = System.Drawing.SystemColors.Control;
            this.lessonsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lessonsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lessonsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lessonsListBox.FormattingEnabled = true;
            this.lessonsListBox.ItemHeight = 25;
            this.lessonsListBox.Location = new System.Drawing.Point(0, 3);
            this.lessonsListBox.Name = "lessonsListBox";
            this.lessonsListBox.Size = new System.Drawing.Size(888, 209);
            this.lessonsListBox.TabIndex = 50;
            // 
            // makeScheduleBtn
            // 
            this.makeScheduleBtn.Location = new System.Drawing.Point(80, 390);
            this.makeScheduleBtn.Name = "makeScheduleBtn";
            this.makeScheduleBtn.Size = new System.Drawing.Size(225, 49);
            this.makeScheduleBtn.TabIndex = 51;
            this.makeScheduleBtn.Text = "Program Oluştur";
            this.makeScheduleBtn.UseVisualStyleBackColor = true;
            this.makeScheduleBtn.Click += new System.EventHandler(this.makeScheduleBtn_Click);
            // 
            // findFacultyBtn
            // 
            this.findFacultyBtn.Enabled = false;
            this.findFacultyBtn.Location = new System.Drawing.Point(1089, 18);
            this.findFacultyBtn.Name = "findFacultyBtn";
            this.findFacultyBtn.Size = new System.Drawing.Size(162, 48);
            this.findFacultyBtn.TabIndex = 52;
            this.findFacultyBtn.Text = "Find Faculty";
            this.findFacultyBtn.UseVisualStyleBackColor = true;
            this.findFacultyBtn.Click += new System.EventHandler(this.findFacultyBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lessonsListBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(80, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 212);
            this.panel1.TabIndex = 53;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 3);
            this.panel2.TabIndex = 54;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(80, 468);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(888, 30);
            this.progressBar.TabIndex = 54;
            // 
            // MakeSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.findFacultyBtn);
            this.Controls.Add(this.makeScheduleBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelFacultyClass);
            this.Controls.Add(this.springAutumnComboBox);
            this.Controls.Add(this.FacultyClassNumberComboBox);
            this.Controls.Add(this.facultiesComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MakeSchedule";
            this.Size = new System.Drawing.Size(1437, 744);
            this.Load += new System.EventHandler(this.MakeSchedule_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox facultiesComboBox;
        private System.Windows.Forms.ComboBox springAutumnComboBox;
        private System.Windows.Forms.Label labelFacultyClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lessonsListBox;
        private System.Windows.Forms.Button makeScheduleBtn;
        private System.Windows.Forms.Button findFacultyBtn;
        private System.Windows.Forms.ComboBox FacultyClassNumberComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
