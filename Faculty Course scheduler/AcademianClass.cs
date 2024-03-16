using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace Faculty_Course_scheduler
{
    public class AcademianClass
    {
        public string AcademianName { get; set; }
        public string AcademianFaculty { get; set; }
        public OneLessonDateClass[,] Dates { get; set; }
        public int AcademianLessonCount { get; set; }

        public AcademianClass()
        {
            //Dates = new bool[10, 5];
            AcademianLessonCount = 0;

            Dates = new OneLessonDateClass[10, 5];

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    OneLessonDateClass lessonDateInfo = new OneLessonDateClass();
                    Dates[i, j] = lessonDateInfo;
                    Dates[i, j].DateavAilability = true;
                }
            }
        }

        public void SetAcademian(string academianName,bool[,] dates,string academianfaculty)
        {
            if ((dates.GetLength(0) == Dates.GetLength(0)) && (dates.GetLength(1) == Dates.GetLength(1)))
            {
                for (int j = 0; j < Dates.GetLength(1); j++)
                {

                    for (int i = 0; i < Dates.GetLength(0); i++)
                    {
                        Dates[i, j].DateavAilability = dates[i, j];
                    }
                }
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
                Dates = this.Dates
            };
        }

        public int academianAvailableTime()
        {
            int availableTime = 0;
            for(int i = 0; i < Dates.GetLength(0);i++)
            {
                for(int j= 0; j < Dates.GetLength(1); j++)
                {
                    if (Dates[i,j].DateavAilability == true)
                    {
                        availableTime++;
                    }
                }
            }
            return availableTime;
        }

        public void SaveWorkDates()
        {
            // Yeni tarihlerin uygun boyutta olup olmadığını kontrol et
            if (Dates.GetLength(0) != Dates.GetLength(0) || Dates.GetLength(1) != Dates.GetLength(1))
            {
                MessageBox.Show("Hata: Dizi uzunlukları arasında uyuşmazlık");
                return;
            }

            // Akademisyenin çalışma tarihlerini güncelle
            //Dates = newDates;
            Database db = new Database();
            db.DeleteAcademian(this.AcademianName);
            db.SaveAcademianDataToJson(this);

        }

        public void UpdateWorkDates()
        {
            Database db = new Database();
            db.DeleteAcademian(this.AcademianName);
            db.SaveAcademianDataToJson(this);
            MessageBox.Show("güncelleme başarılı");
        }
    }
}
