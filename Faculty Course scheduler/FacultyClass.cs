using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Course_scheduler
{
	internal class FacultyClass
	{
		public string facultyName;
		public int facultyPeriod;	//fakülte dönemi
		public int facultyStudents;
		public bool[,] facultyLessonDates;
		public List<LessonClass>[] facultyLessons;

		public FacultyClass()
		{
			facultyLessonDates = new bool[10, 5];	//12 satır 5 sütun
		}
		public void setFaculty(string facultyname, int facultyyear, int facultystudents, List<LessonClass>[] facultylessons)
		{
			facultyName = facultyname;
            facultyPeriod = facultyyear;
			facultyStudents = facultystudents;
			facultyLessons = facultylessons;

        }
	}
}
