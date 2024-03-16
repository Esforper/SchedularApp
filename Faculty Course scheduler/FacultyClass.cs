using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Course_scheduler
{
	public class FacultyClass
	{
		public string FacultyName;
		public int FacultySemester;	//fakülte dönemi
		public int FacultyNumberOfStudents;
		public bool[,] Dates;

		public List<LessonClass>[] FacultyLessons;

		public int facultyClassNumber;

		public FacultyClass()
		{
			Dates = new bool[10, 5];	//12 satır 5 sütun
		}
		public void SetFaculty(string facultyname, int facultyyear, int facultystudents, List<LessonClass>[] facultylessons)
		{
			FacultyName = facultyname;
            FacultySemester = facultyyear;
			FacultyNumberOfStudents = facultystudents;
			FacultyLessons = facultylessons;
			facultyClassNumber = FacultySemester / 2;
        }
	}
}
