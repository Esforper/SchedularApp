using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Course_scheduler.Controller
{
    public partial class sectionInfoPage : UserControl
    {
        Database database = new Database();
        onePeriodFacultyClass section = new onePeriodFacultyClass();
        public sectionInfoPage(string sectionName)
        {
            InitializeComponent();
            section = database.GetOneSection(sectionName);
            
            for (int i = 0; i < section.facultyLessonDates.GetLength(0); i++)   //hücre renklerini ayarlamak için
            {
                for(int j = 0; j < section.facultyLessonDates.GetLength(1); j++)
                {
                    cellColors[i, j] = section.facultyLessonDates[i, j].dateavailability;
                }
            }

        }
        public bool[,] cellColors;

    }
}
