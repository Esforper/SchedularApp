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
            string academianFaculty = facultiesComboBox.Text;
            academian.SetAcademian(academianName, booldizisi,academianFaculty);
            database.SaveAcademian(academian);
        }

        private void addClassBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                CheckBox[,] checkBoxArray = new CheckBox[10, 5];
                bool[,] booldizisi = new bool[10, 5];
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        string checkBoxName = "checkbox_" + (i + j * 10 + 1);
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

                //kapasite değerini inte çevirmeye çalış sonra da yeni class nesnesi oluşturup database ye kaydet
                int capacity_ = Convert.ToInt32(classCapacityTextBox.Text);
                ClassClass class_ = new ClassClass();
                class_.setClass(classNameTextBox.Text, capacity_,booldizisi);
                database.saveClass(class_);
            }
            catch
            {
                MessageBox.Show("int değerinde bir kapasite giriniz");
            }
           
        }



        private int facultyPeriodNumber;
        private int facultyStudentNumber;
        private string facultyname;
        private List<LessonClass>[] facultyLessons;
        private List<LessonClass> lessons;

        private void facultyContinueBtn_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainer2.Panel2.Enabled = true;
                facultyPeriodNumber = Convert.ToInt16(facultyPeriodTextBox.Text);
                facultyStudentNumber = Convert.ToInt16(facultyStudentNumberTextBox.Text);
                facultyname = facultyNameTextBox.Text;

                labelFacultyName.Text = facultyNameTextBox.Text;
                labelFacultyPeriod.Text = facultyStudentNumberTextBox.Text;

                // Liste dizisini oluştur
                facultyLessons = new List<LessonClass>[facultyPeriodNumber];

                for (int i = 0; i < facultyPeriodNumber; i++)
                {
                    // Her bir dönem için bir liste oluştur
                    facultyLessons[i] = new List<LessonClass>();
                }

                for (int i = 1; i < facultyPeriodNumber + 1; i++)
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
                lessonListBox.Items.Add(lessonComboBox.Text + ". Dönem : " + lessonTextBox.Text);
                LessonClass lesson = new LessonClass();
                lesson.lessonName = lessonTextBox.Text;
                lesson.lessonFacultyPeriod = Convert.ToInt16(lessonComboBox.Text);
                lesson.lessonFaculty = facultyname;
                lesson.LessonLong = Convert.ToInt16(lessonLongTextBox.Text);

                // Dersi uygun dönemin listesine ekle
                facultyLessons[lesson.lessonFacultyPeriod - 1].Add(lesson);

                lessons.Add(lesson);
            }
            catch
            {
                MessageBox.Show("bir hata oluştu");
            }
        }

        private void addFacultyBtn_Click(object sender, EventArgs e)
        {
            // facultyLessons dizisini FacultyClass nesnesine ekleyerek kaydet
            FacultyClass faculty = new FacultyClass();
            faculty.setFaculty(facultyname, facultyPeriodNumber, facultyStudentNumber, facultyLessons);
            database.saveFaculty(faculty);
        }

        
        private void informationEntry_Load(object sender, EventArgs e)
        {
            lessons = new List<LessonClass>();
            facultyLessons = new List<LessonClass>[facultyPeriodNumber];

            foreach (string facultName in database.getfaculties())  //Akademisyenin fakültesini seçerken gerekli
            {
                facultiesComboBox.Items.Add(facultName);
            }
        }

        private void SelectAllClass_Click(object sender, EventArgs e)
        {
            // CheckBox90'dan başlayarak diğer checkbox'ları seç
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string checkBoxName = "checkbox_" + (i + j * 10 + 1);
                    CheckBox checkBox = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;

                    if (checkBox != null)
                    {
                        checkBox.Checked = true;
                    }
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
