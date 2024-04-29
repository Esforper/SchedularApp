using Faculty_Course_scheduler.Controller;
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
            splitContainer2.FixedPanel = FixedPanel.Panel1;

        }

        bool isAcademian_MndyLblClick = false;
        bool isAcademian_TsdyLblClick = false;
        bool isAcademian_WdnsdyLblCLick = false;
        bool isAcademian_ThrdyLblClick = false;
        bool isAcademian_FrdyLblClick = false;

        bool isClass_MndyLblClick = false;
        bool isClass_TsdyLblClick = false;
        bool isClass_WdnsdyLblCLick = false;
        bool isClass_ThrdyLblClick = false;
        bool isClass_FrdyLblClick = false;

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

            List<string> lessonCodes = new List<string>();
            foreach(var lessonCode in academianLessonsLstBx.Items)
            {
                lessonCodes.Add(lessonCode.ToString());
            }

            academian.lessonCodes = lessonCodes;    //bunu direkt public olduğu için atama yaptım ama normalde atama yapamamam lazım.
            string academianName = textBox1.Text;
            string academianFaculty = facultiesComboBox.Text;
            academian.SetAcademian(academianName, booldizisi, academianFaculty);
            database.SaveAcademian(academian);
            MessageBox.Show("Akademisyen Kaydedildi");
        }

        private void addLessonToAcademianBtn_Click(object sender, EventArgs e)
        {
            if (!academianLessonsLstBx.Items.Contains(lessonCodesComboBox.Text))
            {
                academianLessonsLstBx.Items.Add(lessonCodesComboBox.Text);
            }
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
                class_.SetClass(classNameTextBox.Text, capacity_,booldizisi);
                database.SaveClass(class_);
                MessageBox.Show("Derslik veritabanına kaydedildi");
            }
            catch
            {
                MessageBox.Show("int değerinde bir kapasite giriniz");
            }
           
        }


        // ---------- DEPARTMENT ADD SYSTEM -----------
        private int departmentPeriodNumber; //departmanda kaç dönem var (bil müh için 8 dönem gibi)
        private string facultyname; //seçili fakülte (department de denebilir) bilgilerini kaydet.
        private List<LessonClass>[] facultyLessons; //fakülte derslerinin kaydedileceği "Listelerin dizisi"

        private List<SectionStudentNumberControl> studentNumberPanelList;   //Bilgilerin alınabilmesi için panel listesi
        //List<int> studentNumbersList = new List<int>();

        private int[] gradeStudentCount;

        private void facultyContinueBtn_Click(object sender, EventArgs e)
        {
            
            studentNumberPanelList = new List<SectionStudentNumberControl>();
            try
            {
                departmentPeriodNumber = Convert.ToInt16(facultyPeriodTextBox.Text);
                facultyLessons = new List<LessonClass>[departmentPeriodNumber];    //fakülte derslerini tanımladık

                //dizi için ayrı ayrı listeleri tanımlıyoruz.
                for(int i=0; i < departmentPeriodNumber; i++)
                {
                    facultyLessons[i] = new List<LessonClass>();
                }

                gradeStudentNumberPnl.Visible = true;   // genel panel visibilty
                //her gradenin öğrenci sayısının girildiği ana panel görünümünü ayarla

                gradeStudentNumberPanel.Controls.Clear();
                //tekrar tekrar eklemeye karşın, input girişi user controllerin bulunacağı list paneli üzerindeki ögeleri temizle

                for (int i = 1; i < departmentPeriodNumber / 2 + 1 ; i++)
                {
                    SectionStudentNumberControl studentNumberPanel = new SectionStudentNumberControl(i);  //grade öğrenci sayısı input paneli
                    studentNumberPanelList.Add(studentNumberPanel); //panellere erişmek için listeye kaydet
                    gradeStudentNumberPanel.Controls.Add(studentNumberPanel);   
                }
                
                
                facultyname = facultyNameTextBox.Text;  //fakülte ismini çek
                labelFacultyName.Text = facultyname;
            }
            catch
            {
                MessageBox.Show("int türünde değer girin");
            }
            
            
        }

        private void gradeStudentNumberBtn_Click(object sender, EventArgs e)
        {
            
            goToSemesterPnl.Dock = DockStyle.Bottom;
            gradeStudentNumberPnl.Dock = DockStyle.Fill;
            /*
            foreach (SectionStudentNumberControl obj in studentNumberPanelList)
            {
                studentNumbersList.Add(obj.GetStudentNumber());
            }
            */
            //studentNumberListPanel -> bilgi girişinin sağlandığı user control paneller
            //studentNumbersList -> int türünde sınıfların öğrenci sayısı değerlerini tutuyor

            for (int i = 1; i < departmentPeriodNumber+1; i++)
            {
                semesterSelectInput.Items.Add(i);
            }
            //SemesterSelect -> hangi sınıfın bilgilerini eklediğimizi seçtiğimiz input
            //facultyPeriodNumber -> departmentin (bölümün) dönem sayısı
            //bölümün dönem sayısı kadar comboboxa öge ekliyor

            goToSemesterPnl.Visible = true;
            //erişilmek istenen dönemin bilgilerinin girildiği panelin görünürlüğü

            gradeStudentCount = new int[departmentPeriodNumber / 2];
            for(int i = 0; i < studentNumberPanelList.Count(); i++)
            {
                gradeStudentCount[i] = studentNumberPanelList[i].GetStudentNumber();
            }
            
        }

        int selectedSemester = 0;
        private void goToSemesterBtn_Click(object sender, EventArgs e)
        {
            selectedSemester = Convert.ToInt16(semesterSelectInput.Text);

            splitContainer2.Panel2.Enabled = true;
            lblSelectedSemester.Text = selectedSemester.ToString();
            //seçilen dönemi göster (1. dönem, 3. dönem vb)
        }

        List<LessonClass> AllLessons = new List<LessonClass>();
        private void addLessonBtn_Click(object sender, EventArgs e)
        {
            try
            {

                LessonClass lesson = new LessonClass
                {
                    Name = lessonTextBox.Text,
                    LessonSemester = Convert.ToInt16(selectedSemester),
                    Department = facultyname,
                    LessonCode = LessonCodeInput.Text.ToUpper(),
                    AKTS = Convert.ToInt16(AKTSInput.Text),
                    Credit = Convert.ToInt16(CreditInput.Text)
                };

                //ders sürelerini ekle
                lesson.LessonDuration[0] = Convert.ToInt16(teorikInput.Text);
                lesson.LessonDuration[1] = Convert.ToInt16(uygulamaInput.Text);
                lesson.LessonDuration[2] = Convert.ToInt16(labInput.Text);

                AllLessons.Add(lesson);
                lessonListBox.Items.Add(selectedSemester + ". Dönem : " + lesson.LessonCode + " : " + lesson.Name);
                facultyLessons[lesson.LessonSemester - 1].Add(lesson);
            }
            catch
            {
                //MessageBox.Show("bir hata oluştu"); bu yorum satırı daha sonra geri çekilecek
            }
        }

        private void nextSemesterPeriod_Click(object sender, EventArgs e)
        {
            selectedSemester++;
            lblSelectedSemester.Text = selectedSemester.ToString();
        }


        private void addFacultyBtn_Click(object sender, EventArgs e)
        {
            // facultyLessons dizisini FacultyClass nesnesine ekleyerek kaydet
            DepartmentClass department = new DepartmentClass();
            department.SetFaculty(facultyname, departmentPeriodNumber, gradeStudentCount, facultyLessons);
            database.SaveDepartment(department);
        }
        //--------------- END OF ADD DEPARTMENT SYSTEM ----------------
        
        private void informationEntry_Load(object sender, EventArgs e)
        {
            if(database.Getfaculties() != null)
            {
                List<DepartmentClass> AllDepartments = database.AllDepartments;
                List<string> AllLessonCodes = new List<string>();
                foreach(DepartmentClass department in AllDepartments)
                {
                    foreach(var listOfLessons in department.courses)
                    {
                        foreach(var oneLesson in listOfLessons)
                        {
                            if (!AllLessonCodes.Contains(oneLesson.LessonCode))
                            {
                                AllLessonCodes.Add(oneLesson.LessonCode);
                                lessonCodesComboBox.Items.Add(oneLesson.LessonCode);
                            }
                            
                        }
                    }
                }
                


                foreach (string facultName in database.Getfaculties())  //Akademisyenin fakültesini seçerken gerekli
                {
                    if(facultName != null)
                    {
                        facultiesComboBox.Items.Add(facultName);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Fakülte Tanımlanmamış");
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

        // --- SELECT ALL DAY LABEL CLİCK METHODS --- 
        private void mndyLabel_Click(object sender, EventArgs e)
        {
            if(isAcademian_MndyLblClick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isAcademian_MndyLblClick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isAcademian_MndyLblClick = false;
            }

        }

        private void tsdyLabel_Click(object sender, EventArgs e)
        {
            
            if (isAcademian_TsdyLblClick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (10 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isAcademian_TsdyLblClick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (10 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isAcademian_TsdyLblClick = false;
            }
        }

        private void wdnsdyLabel_Click(object sender, EventArgs e)
        {
            if (isAcademian_WdnsdyLblCLick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (20 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isAcademian_WdnsdyLblCLick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (20 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isAcademian_WdnsdyLblCLick = false;
            }
        }

        private void thrsdyLabel_Click(object sender, EventArgs e)
        {
            if (isAcademian_ThrdyLblClick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (30 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isAcademian_ThrdyLblClick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (30 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isAcademian_ThrdyLblClick = false;
            }
        }

        private void frdyLabel_Click(object sender, EventArgs e)
        {
            if (isAcademian_FrdyLblClick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (40 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isAcademian_FrdyLblClick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox" + (40 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isAcademian_FrdyLblClick = false;
            }
        }


        // --- --- ADD CLASS SELECT ALL DAY METHODS ------
        private void clssMndyLbl_Click(object sender, EventArgs e)
        {
            if (isClass_MndyLblClick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isClass_MndyLblClick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isClass_MndyLblClick = false;
            }
        }

        private void clssTsdyLbl_Click(object sender, EventArgs e)
        {
            if (isClass_TsdyLblClick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (10 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isClass_TsdyLblClick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (10 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isClass_TsdyLblClick = false;
            }
        }

        private void clssWdnsdyLbl_Click(object sender, EventArgs e)
        {
            if (isClass_WdnsdyLblCLick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (20 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isClass_WdnsdyLblCLick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (20 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isClass_WdnsdyLblCLick = false;
            }
        }

        private void clssThrsdyLbl_Click(object sender, EventArgs e)
        {
            if (isClass_ThrdyLblClick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (30 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isClass_ThrdyLblClick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (30 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isClass_ThrdyLblClick = false;
            }
        }

        private void clssFrdyLbl_Click(object sender, EventArgs e)
        {
            if (isClass_FrdyLblClick == false)
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (40 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = true;
                }
                isClass_FrdyLblClick = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    string checkBoxName = "checkbox_" + (40 + i + 1);
                    CheckBox chkbx = this.Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                    chkbx.Checked = false;
                }
                isClass_FrdyLblClick = false;
            }
        }

       



        //----


    }
}
