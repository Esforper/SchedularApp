using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace Faculty_Course_scheduler
{
    internal class AcademianClass
    {
        public string AcademianName { get; set; }
        public string AcademianFaculty { get; set; }
        public bool[,] AcademianWorkDates { get; set; }

        public AcademianClass()
        {
            AcademianWorkDates = new bool[10, 5];
        }

        public void SetAcademian(string academianName,bool[,] dates,string academianfaculty)
        {
            if ((dates.GetLength(0) == AcademianWorkDates.GetLength(0)) && (dates.GetLength(1) == AcademianWorkDates.GetLength(1)))
            {
                AcademianWorkDates = dates;
            }
            else
            {
                MessageBox.Show("Hata: Dizi uzunlukları arasında uyuşmazlık");
            }
            AcademianName = academianName;
            AcademianFaculty = academianfaculty;
            SaveAcademian();
        }

        private void SaveAcademian()
        {
            AcademianClass academian = new AcademianClass
            {
                AcademianName = this.AcademianName,
                AcademianWorkDates = this.AcademianWorkDates
            };
        }

        public int academianAvailableTime()
        {
            int availableTime = 0;
            for(int i = 0; i < AcademianWorkDates.GetLength(0);i++)
            {
                for(int j= 0; j < AcademianWorkDates.GetLength(1); j++)
                {
                    if (AcademianWorkDates[i,j] == true)
                    {
                        availableTime++;
                    }
                }
            }
            return availableTime;
        }
    }
}
