using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Course_scheduler
{
    internal class LessonClass
    {
        public string lessonName;
        public string lessonFaculty;
        public int LessonLong;
        public int lessonFacultyPeriod;

    }

    class onePeriodFacultyClass
    {
        //Bilgisayar mühendisliği 1. sınıf, 2.sınıf gibi düşün
        public string PeriodName;      //kod içerisinde otomatik oluşturulacak ve bilgisayar müh 1.sınıf, 2. sınıf gibi bir etkisi olucak.
        public List<LessonClass> Lessons;   //ders listesi olucak
        public oneLessonDateClass[,] facultyLessonDates;  //ders tarihleri olucak.
        public string periodFaculty;
        public int periodStudentCapacity;

        public onePeriodFacultyClass()
        {
            facultyLessonDates = new oneLessonDateClass[10, 5];
            
            for(int j=0; j < 5; j++)
            {
                for(int i=0; i < 10; i++)
                {
                    oneLessonDateClass lessonDateInfo = new oneLessonDateClass();
                    facultyLessonDates[i,j] = lessonDateInfo;
                    facultyLessonDates[i,j].dateavailability = true;
                }
            }
        }

        public void UpdateOneSection()
        {
            /*
            Database db = new Database();
            db.DeleteAcademian(this.AcademianName);
            db.SaveAcademianDataToJson(this);
            MessageBox.Show("güncelleme başarılı");
            // şimdilik dursun ama değişecek
             */
        }
    }

    class oneLessonDateClass
    {
        public bool dateavailability;
        public string lessonAcademian;
        public string lessonClass;
        public string lessonName;
    }

}
