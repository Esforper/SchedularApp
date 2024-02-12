using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Course_scheduler
{
	public partial class informationEntry : UserControl
	{
		public informationEntry()
		{
			InitializeComponent();
     
		}
        Database database = new Database();
        private void button4_Click(object sender, EventArgs e)
        {
          
            AcademianClass academian = new AcademianClass();
            CheckBox[,] checkBoxArray = new CheckBox[10, 5];
            bool[,] booldizisi = new bool[10, 5];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string checkBoxName = "checkbox" + (i + j * 10 + 1);
                    checkBoxArray[i, j] = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                }
            }

            for (int i = 0; i < checkBoxArray.GetLength(0); i++)
            {
                for (int j = 0; j < checkBoxArray.GetLength(1); j++)
                {
                    booldizisi[i, j] = checkBoxArray[i, j].Checked;
                }
            }

            string academianName = textBox1.Text;
            academian.SetAcademian(academianName, booldizisi);
            database.SaveAcademian(academian);
        }

        private void addClassBtn_Click(object sender, EventArgs e)
        {
            try
            {   //kapasite değerini inte çevirmeye çalış sonra da yeni class nesnesi oluşturup database ye kaydet
                int capacity_ = Convert.ToInt32(classCapacityTextBox.Text);
                ClassClass class_ = new ClassClass();
                class_.setClass(classNameTextBox.Text, capacity_);
                database.saveClass(class_);
            }
            catch
            {
                MessageBox.Show("int değerinde bir kapasite giriniz");
            }
           
        }

        

        int facultyPeriodNumber;    //bir fakültenin kaç dönem olduğunu tutuyor.
        int facultyStudentNumber;   //fakültedeki öğrenci sayısı
        string facultyname;         //fakülte ismi
        List<LessonClass> lessons;
        private void facultyContinueBtn_Click(object sender, EventArgs e)
        {
            try
            {
                facultyPeriodNumber = Convert.ToInt16(facultyPeriodTextBox.Text);
                facultyStudentNumber = Convert.ToInt16(facultyStudentNumberTextBox.Text);
                facultyname = facultyNameTextBox.Text;

                labelFacultyName.Text = facultyNameTextBox.Text;
                labelFacultyPeriod.Text = facultyStudentNumberTextBox.Text;

                for(int i = 1;i< facultyPeriodNumber + 1; i++)
                {
                    lessonComboBox.Items.Add(i);
                }
                lessonComboBox.SelectedItem = 1;
            }
            catch
            {
                MessageBox.Show("int türünde değer girin");
            }
            
        }

        private void addLessonBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                lessons = new List<LessonClass>();
                lessonListBox.Items.Add(lessonComboBox.Text + " : " + lessonTextBox.Text);
                LessonClass lesson = new LessonClass();
                lesson.lessonName = lessonTextBox.Text;
                lesson.lessonFacultyPeriod = Convert.ToInt16(lessonComboBox.Text);
                lesson.lessonFaculty = facultyname;
                lessons.Add(lesson);
            }
            catch
            {
                MessageBox.Show("bir hata oluştu");
            }
        }

        private void addFacultyBtn_Click(object sender, EventArgs e)
        {
            List<LessonClass>[] facultyLessons= new List<LessonClass>[facultyPeriodNumber];
            FacultyClass faculty = new FacultyClass();
            faculty.setFaculty(facultyname, facultyPeriodNumber, facultyStudentNumber, facultyLessons);
            database.saveFaculty(faculty);
        }
    }
}
