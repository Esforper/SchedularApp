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

    class onePeriodFaculty
    {
        //Bilgisayar mühendisliği 1. sınıf, 2.sınıf gibi düşün
        public string PeriodName;
        public List<LessonClass> Lessons;
        public bool[,] facultyLessonDates;

        onePeriodFaculty()
        {
            facultyLessonDates = new bool[10, 5];
        }
    }

}
