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
		public int FacultySemester;	//fakülte dönem sayısı
		//public int FacultyNumberOfStudents;
		//public bool[,] Dates;
		public int[] StudentNumbers;

		public List<LessonClass>[] FacultyLessons;

		public int facultyClassNumber;	//fakültedeki sınıf sayısı

		public FacultyClass()
		{
			//Dates = new bool[10, 5];	//12 satır 5 sütun
		}
		public void SetFaculty(string facultyname, int facultyyear, int[] facultystudents, List<LessonClass>[] facultylessons)
		{
			FacultyName = facultyname;
            FacultySemester = facultyyear;
            StudentNumbers = facultystudents;
			FacultyLessons = facultylessons;
			facultyClassNumber = FacultySemester / 2;
        }
	}
}
