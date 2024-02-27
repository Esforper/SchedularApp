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
        public bool[,] facultyLessonDates;  //ders tarihleri olucak.
        public string periodFaculty;
        public int periodStudentCapacity;

        public onePeriodFacultyClass()
        {
            facultyLessonDates = new bool[10, 5];
        }
    }

}
