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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bölümü Seçiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sınıfı Seçiniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dönem Seçiniz:";
            // 
            // facultiesComboBox
            // 
            this.facultiesComboBox.FormattingEnabled = true;
            this.facultiesComboBox.Location = new System.Drawing.Point(281, 110);
            this.facultiesComboBox.Name = "facultiesComboBox";
            this.facultiesComboBox.Size = new System.Drawing.Size(172, 28);
            this.facultiesComboBox.TabIndex = 45;
            this.facultiesComboBox.SelectedIndexChanged += new System.EventHandler(this.facultiesComboBox_SelectedIndexChanged);
            // 
            // FacultyClassNumberComboBox
            // 
            this.FacultyClassNumberComboBox.FormattingEnabled = true;
            this.FacultyClassNumberComboBox.Location = new System.Drawing.Point(281, 152);
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
            this.springAutumnComboBox.Location = new System.Drawing.Point(281, 196);
            this.springAutumnComboBox.Name = "springAutumnComboBox";
            this.springAutumnComboBox.Size = new System.Drawing.Size(172, 28);
            this.springAutumnComboBox.TabIndex = 47;
            this.springAutumnComboBox.SelectedIndexChanged += new System.EventHandler(this.springAutumnComboBox_SelectedIndexChanged);
            // 
            // labelFacultyClass
            // 
            this.labelFacultyClass.AutoSize = true;
            this.labelFacultyClass.Location = new System.Drawing.Point(714, 68);
            this.labelFacultyClass.Name = "labelFacultyClass";
            this.labelFacultyClass.Size = new System.Drawing.Size(204, 20);
            this.labelFacultyClass.TabIndex = 48;
            this.labelFacultyClass.Text = "<Fakülte : Sınıfı : Dönem>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "Dersler";
            // 
            // lessonsListBox
            // 
            this.lessonsListBox.FormattingEnabled = true;
            this.lessonsListBox.ItemHeight = 20;
            this.lessonsListBox.Location = new System.Drawing.Point(550, 140);
            this.lessonsListBox.Name = "lessonsListBox";
            this.lessonsListBox.Size = new System.Drawing.Size(499, 204);
            this.lessonsListBox.TabIndex = 50;
            // 
            // makeScheduleBtn
            // 
            this.makeScheduleBtn.Location = new System.Drawing.Point(423, 394);
            this.makeScheduleBtn.Name = "makeScheduleBtn";
            this.makeScheduleBtn.Size = new System.Drawing.Size(225, 49);
            this.makeScheduleBtn.TabIndex = 51;
            this.makeScheduleBtn.Text = "button1";
            this.makeScheduleBtn.UseVisualStyleBackColor = true;
            this.makeScheduleBtn.Click += new System.EventHandler(this.makeScheduleBtn_Click);
            // 
            // findFacultyBtn
            // 
            this.findFacultyBtn.Enabled = false;
            this.findFacultyBtn.Location = new System.Drawing.Point(206, 258);
            this.findFacultyBtn.Name = "findFacultyBtn";
            this.findFacultyBtn.Size = new System.Drawing.Size(162, 48);
            this.findFacultyBtn.TabIndex = 52;
            this.findFacultyBtn.Text = "Find Faculty";
            this.findFacultyBtn.UseVisualStyleBackColor = true;
            this.findFacultyBtn.Click += new System.EventHandler(this.findFacultyBtn_Click);
            // 
            // MakeSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.findFacultyBtn);
            this.Controls.Add(this.makeScheduleBtn);
            this.Controls.Add(this.lessonsListBox);
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
    }
}
