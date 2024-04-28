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
    public partial class makeCourseSchedule : UserControl
    {
        Database db = new Database();
        public makeCourseSchedule()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Yapılacaklar
        /// Department sıralanması sağlanacak (anlık olarak pc müh. den başlayarak alfabetik sıralanması gerekiyor
        /// sınıf kapasitesi ders koduna göre ayarlanacağı için sınıf sayısını tutma
        /// her bir takvim hücresi için ders kodunu tutsun sadece, ders kodu varsa doldu, yoksa değil şeklinde
        ///     verim açısından da işlevli olur
        /// </summary>

        void makeScheduleFunc(string semester)
        {
            int semesterNum =  SemesterToInt(semester);
            //Fall = 0 , Spring = 1 , else = -1

            //Önce tüm sınıf ve gradeleri tanımlamamız lazım
            //liste şeklinde semesterclass yapabiliriz (listenin listesi ya da listenin dizisi olabilir)
            List<DepartmentClass>AllDepartments = db.AllDepartments;
            //bilgisayar müh, yazılım müh, gibi tüm bölümlerin listesi
            
            AllDepartments = AllDepartments.OrderBy(department => department.Name).ToList();
            //Alfabetik olarak sıralanacak (bu kısım sıralanması daha sonra ayarlanacak

            //tüm bölümleri tanımlamam lazım
            //departmentlar bilgisayar , yazılım gibi, semester olarak tanımlamam lazım

            List<SemesterClass> AllSemesters = new List<SemesterClass>();
            foreach(DepartmentClass department in AllDepartments)   //department dönme
            {
                for(int i = 0;i< department.numGrades;i++)  //sınıf sayısı kadar dön
                {
                    SemesterClass oneSemester = new SemesterClass();    //semester oluşturma
                    oneSemester.Name = department.Name + "_" + i + "_" + semester;
                    //bölüm + sınıf numarası + dönemi
                    //semester student capacity kaldırılacak
                    oneSemester.FacultyName = department.Name;
                    oneSemester.Lessons = department.courses[department.numGrades+semesterNum];
                    //bu değerlerin kontrolleri sağlanacak
                    AllSemesters.Add(oneSemester);
                }
            }
           //Bu kısım ön tanımlama, ortak ders saatleri olduğunda olası çakışmaları engellemesi için.


            for(int i = 0; i < 4; i++)  //bölümler 4 senelik olduğu var sayılarak dönülüyor
            //sınıfları dön
            {
                foreach(DepartmentClass department in AllDepartments)
                {


                }
            }
            

        }

        int SemesterToInt(string semesterName) {
            if(semesterName == fallRdBtn.Text)
            {
                return 0;
            }
            else if(semesterName == springRdBtn.Text)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string selectedSemester = "";
           if(fallRdBtn.Checked)
            {
                selectedSemester = fallRdBtn.Text;
            }
           else if(springRdBtn.Checked)
            {
                selectedSemester=springRdBtn.Text;
            }
            else
            {
                MessageBox.Show("Bir dönem seçiniz");
            }

           if(selectedSemester != "")
            {
                makeScheduleFunc(selectedSemester);
            }
        }
    }
}
