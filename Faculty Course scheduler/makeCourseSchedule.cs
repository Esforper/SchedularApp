﻿using System;
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

            List<SemesterClass>[] AllSemesters = new List<SemesterClass>[6];
            for(int i = 0; i < 6; i++)  //All semester Liste dizisinin Liste sayısı kadar döndür
            {
                List<SemesterClass> listOfSemesters = new List<SemesterClass> ();
                AllSemesters[i] = listOfSemesters;
            }


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
                    AllSemesters[i].Add(oneSemester);
                    
                    //Her departman ve o departmandaki sınıf sayısını döndürdük (yani bil 1.grade , bil 2.grade gibi döndür)
                    //Semester classa (bil 1.sınıf gibi) isim ataması, fakülte ismini, ders listesini ata.
                    // !!! Tüm semesterların listesinin dizisinde , kendi sınıf listesine kaydet
                    //sonuç olarak bil 1. sınıflar 1.sınıfların listesinde, bil 2.sınıf 2.sınıfların listesinde kayıtlı olacak.

                }
            }
           //Bu kısım ön tanımlama, ortak ders saatleri olduğunda olası çakışmaları engellemesi için.


            for(int i = 0; i < 6; i++)  //bir bölüm max 6 dönem olabildiğinden 6 var sayılıyor.
            //sınıfları dön
            {
                /*
                foreach(DepartmentClass department in AllDepartments) {  }
                */
                foreach(SemesterClass oneSemester in AllSemesters[i])
                {
                    foreach(LessonClass lesson in oneSemester.Lessons)
                    {
                        for(int k = 0; k < 2; k++)  //teorik ve uygulama
                        {

                        }

                        for(int j=1;j<2; j++)   //sırf lab için tek sefer dönecek (verimsel olarak sıkıntılı ama kodun düzeni için şimdilik dursun)
                        {

                        }
                    }
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
