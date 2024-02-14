using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Course_scheduler.Controller
{
    internal class ScheduleGenerator
    {
        public static void GenerateSchedule(Database database)
        {
            List<AcademianClass> academians = database.AllAcademians;
            List<FacultyClass> faculties = database.AllFaculties;
            List<ClassClass> classes = database.AllClasses;

            foreach(AcademianClass academian in academians)
            {
                



                for(int j=0; j<5; j++)
                {

                }
            }

        }
    }
}
