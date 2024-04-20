namespace Faculty_Course_scheduler.Controller
{
    partial class SectionStudentNumber
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
            this.label = new System.Windows.Forms.Label();
            this.studentNumberInputBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(40, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(220, 25);
            this.label.TabIndex = 0;
            this.label.Text = "1.Grade Öğrenci Sayısı:";
            // 
            // studentNumberInputBox
            // 
            this.studentNumberInputBox.Location = new System.Drawing.Point(266, 6);
            this.studentNumberInputBox.Mask = "00000";
            this.studentNumberInputBox.Name = "studentNumberInputBox";
            this.studentNumberInputBox.Size = new System.Drawing.Size(75, 30);
            this.studentNumberInputBox.TabIndex = 1;
            this.studentNumberInputBox.ValidatingType = typeof(int);
            // 
            // SectionStudentNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.studentNumberInputBox);
            this.Controls.Add(this.label);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SectionStudentNumber";
            this.Size = new System.Drawing.Size(397, 44);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.MaskedTextBox studentNumberInputBox;
    }
}
