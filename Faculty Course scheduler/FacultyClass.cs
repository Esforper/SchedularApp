using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Course_scheduler
{
	internal class FacultyClass
	{
		private string facultyName;
		private int facultyDegree;
		public bool[,] facultyLessonDates;

		public FacultyClass()
		{
			facultyLessonDates = new bool[10, 5];	//12 satır 5 sütun
		}
	}
}
