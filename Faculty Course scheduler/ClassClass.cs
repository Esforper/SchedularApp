using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Course_scheduler
{
    internal class ClassClass
    {
        public string className;
        public int classCapacity;
        public bool[,] classDates;

        
        public ClassClass()
        {
            classDates = new bool[10, 5];   //10 satır 5 sütun
        }
        public void setClass(string className_,int capacity_, bool[,] dates)
        {
            if ((dates.GetLength(0) == classDates.GetLength(0)) && (dates.GetLength(1) == classDates.GetLength(1)))
            {
                classDates = dates;
                className = className_;
                classCapacity = capacity_;
            }
            else
            {
                MessageBox.Show("Hata: Dizi uzunlukları arasında uyuşmazlık");
            }
            className = className_;
            classCapacity = capacity_;
        }

        public void UpdateClassDates()  //database yi direkt güncelliyor aslında, dateyi güncellemiyor
        {
            Database db = new Database();//database classı çağır.
            db.DeleteClass(this.className); //classı sil
            db.saveClass(this); //classı tekrar kaydet
            MessageBox.Show("güncelleme başarılı");
        }



    }
}
