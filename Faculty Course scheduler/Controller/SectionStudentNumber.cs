using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Course_scheduler.Controller
{
    public partial class SectionStudentNumber : UserControl
    {
        int grade;
        public SectionStudentNumber(int grade)
        {
            InitializeComponent();
            label.Text = $"{grade}.Grade Öğrenci Sayısı:";
            this.grade = grade;
        }
        

        public int GetStudentNumber()
        {
            try
            {
                return Convert.ToInt32(studentNumberInputBox.Text);
            }
            catch
            {
                MessageBox.Show($"{grade}.Sınıf değerini lütfen uygun şekilde girin");
                return -1;

            }
            
        }
    }
    
}
