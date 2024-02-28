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
        public bool[,] cellColors = new bool[10,5];

        private void sectionInfoPage_Load(object sender, EventArgs e)
        {
            int saatControl = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Dock = DockStyle.Fill;
                    //label.Text = "Label " + (i * 5 + j + 1);

                    label.Text = saatAyarla(saatControl);
                    saatControl++;

                    label.TextAlign = ContentAlignment.MiddleCenter;
                    DateTable.Controls.Add(label, j, i);
                    if (cellColors[i, j] == true)
                    {
                        label.BackColor = Color.Green;
                    }
                    else
                    {
                        label.BackColor = Color.Gray;

                    }
                }
            }
        }
        public string saatAyarla(int i)
        {
            int saat = (i / 5) + 8;

            string sonuc = string.Format("{0}.30", saat);
            return sonuc;
        }
    }
}
