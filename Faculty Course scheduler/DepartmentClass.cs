using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Course_scheduler
{
	public class DepartmentClass
	{
		public string Name;
		public int NumSemesters;	//fakülte dönem sayısı
		public int[] enrollment;	//1.sınıfların öğrenci sayısı, 2.sınıfların öğrenci sayısı şeklinde
		public List<LessonClass>[] courses;
		public int numGrades;	//fakültedeki sınıf sayısı

		public DepartmentClass()
		{
			
		}
		public void SetFaculty(string facultyname, int facultyyear, int[] facultystudents, List<LessonClass>[] facultylessons)
		{
			Name = facultyname;
            NumSemesters = facultyyear;
            enrollment = facultystudents;
			courses = facultylessons;
			numGrades = NumSemesters / 2;
        }
	}
}

/*Temp
 *public int FacultyNumberOfStudents;
 *public bool[,] Dates;
 //Dates = new bool[10, 5];	//12 satır 5 sütun
 */ 