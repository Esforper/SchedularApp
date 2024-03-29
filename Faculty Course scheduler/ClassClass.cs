﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Course_scheduler
{
    public class ClassClass
    {
        public string Name;
        public int Capacity;
        public OneLessonDateClass[,] Dates;

        public ClassClass()
        {
            //Dates = new bool[10, 5];   //10 satır 5 sütun

            
             Dates = new OneLessonDateClass[10, 5];
            
            for(int j=0; j < 5; j++)
            {
                for(int i=0; i < 10; i++)
                {
                    OneLessonDateClass lessonDateInfo = new OneLessonDateClass();
                    Dates[i,j] = lessonDateInfo;
                    Dates[i,j].DateavAilability = true;
                }
            }
            
        }
        public void SetClass(string className,int classCapacity, bool[,] dates)
        {
            if ((dates.GetLength(0) == Dates.GetLength(0)) && (dates.GetLength(1) == Dates.GetLength(1)))
            {
                for(int j = 0; j < Dates.GetLength(1); j++)
                {
                    for (int i = 0; i < Dates.GetLength(0); i++)
                    {
                        Dates[i,j].DateavAilability = dates[i,j];
                    }
                }


                //Dates = dates;
                Name = className;
                Capacity = classCapacity;
            }
            else
            {
                MessageBox.Show("Hata: Dizi uzunlukları arasında uyuşmazlık");
            }
            Name = className;
            Capacity = classCapacity;
        }

        public void UpdateClassDates()  //database yi direkt güncelliyor aslında, dateyi güncellemiyor
        {
            Database db = new Database();//database classı çağır.
            db.DeleteClass(this.Name); //classı sil
            db.SaveClass(this); //classı tekrar kaydet
            //MessageBox.Show("güncelleme başarılı");
        }

        public int ClassAvailableTime()
        {
            int availableTime = 0;
            for (int i = 0; i < Dates.GetLength(0); i++)
            {
                for (int j = 0; j < Dates.GetLength(1); j++)
                {
                    if (Dates[i, j].DateavAilability == true)
                    {
                        availableTime++;
                    }
                }
            }
            return availableTime;
        }

    }
}
