using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Course_scheduler
{
    public class LessonClass
    {
        public string Name;
        public string Faculty;
        public int LessonDuration;
        public int LessonSemester;
        public string LessonCode;

    }

    class SemesterClass
    {
        //Bilgisayar mühendisliği 1. sınıf, 2.sınıf gibi düşün
        public string Name;      //kod içerisinde otomatik oluşturulacak ve bilgisayar müh 1.sınıf, 2. sınıf gibi bir etkisi olucak.
        public List<LessonClass> Lessons;   //ders listesi olucak
        public OneLessonDateClass[,] Dates;  //ders tarihleri olucak.
        public string FacultyName;
        public int StudentCapacity;

        public SemesterClass()
        {
            Dates = new OneLessonDateClass[10, 5];
            
            for(int j=0; j < 5; j++)
            {
                for(int i=0; i < 10; i++)
                {
                    OneLessonDateClass lessonDateInfo = new OneLessonDateClass();
                    Dates[i,j] = lessonDateInfo;
                    Dates[i,j].DateavAilability = true;
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

    public class OneLessonDateClass
    {
        public bool DateavAilability;
        public string LessonAcademian;
        public string LessonClass;
        public string LessonName;
    }

}
