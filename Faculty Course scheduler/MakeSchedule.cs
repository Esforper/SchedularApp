﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Faculty_Course_scheduler
{
    public partial class MakeSchedule : UserControl
    {
        public MakeSchedule()
        {
            InitializeComponent();
        }

        Database database = new Database();


        private void MakeSchedule_Load(object sender, EventArgs e)
        {
            foreach (string facultName in database.Getfaculties())  //Akademisyenin fakültesini seçerken gerekli
            {
                facultiesComboBox.Items.Add(facultName);
            }

            facultiesComboBox.Text = "Lütfen bir Bölüm Seçiniz";
            FacultyClassNumberComboBox.Text = "Bir sınıf seçiniz";
            
            /*
            for (int i = 0; i < 4; i++)
            {
                FacultyClassNumberComboBox.Items.Add(i + 1);
            }
            */

        }

        private void facultiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {        }
        
        private void facultiesComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            FacultyClassNumberComboBox.Items.Clear();

            var faculties = database.LoadFacultyDataFromJson();
            var onefaculty = faculties.Where(a => a.FacultyName == facultiesComboBox.Text).First();

            for (int i = 0; i < onefaculty.facultyClassNumber; i++)
            {
                FacultyClassNumberComboBox.Items.Add(i + 1);
            }
        }


        private void springAutumnComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            findFacultyBtn.Enabled = true;

        }

        SemesterClass onePeriod;  //bilgisayar müh 1. sınıf gibi 

        private void findFacultyBtn_Click(object sender, EventArgs e)
        {
            lessonsListBox.Items.Clear();

            string facultyInfo = facultiesComboBox.Text;    //hangi fakülte, bilgisini al.

            string facultyPeriodName = facultyInfo + " - " + FacultyClassNumberComboBox.Text + ". Sınıf" + " - " + springAutumnComboBox.Text + " dönemi";
            labelFacultyClass.Text = facultyPeriodName; //fakülte - sınıf - dönem bilgisi

            int selectedPeriod = springAutumnComboBox.SelectedIndex;
            int selectedClass = Convert.ToInt16(FacultyClassNumberComboBox.Text);

            var allfaculties = database.LoadFacultyDataFromJson();

            var selectedFaculty = allfaculties.Find(a => a.FacultyName.Equals(facultiesComboBox.Text));
            int selectedPeriodInt = selectedPeriod + (selectedClass - 1) * 2;   

            var selectedPeriodLessons = selectedFaculty.FacultyLessons[selectedPeriodInt];

            onePeriod = new SemesterClass();
            onePeriod.Lessons = selectedPeriodLessons;  //yeni oluşturulan period classına dersleri koy.
            onePeriod.Name = facultyPeriodName;   //fakülte - sınıf - dönem bilgisi
            onePeriod.FacultyName = facultyInfo;      //hangi fakültenin
            onePeriod.StudentCapacity = selectedFaculty.FacultyNumberOfStudents;  //öğrenci kapasitesi

            foreach (var lesson in selectedPeriodLessons)
            {
                lessonsListBox.Items.Add(lesson.Name);
            }
            
        }

        private void makeScheduleBtn_Click(object sender, EventArgs e)
        {
            var allAcademians = database.LoadAcademianDataFromJson();   //önce tüm akademisyenleri çağır
            var allClass = database.LoadClassDataFromJson();    //tüm sınıfları çağır
            var facultyAcademians = allAcademians.FindAll(a => a.AcademianFaculty == onePeriod.FacultyName).ToList();
            /** Kurallar
             * Her ders için bir hoca olmalı
             * bir ders bir sınıfta olmalı
             * bir bölüm (bilgisayar müh 1. sınıf (period denebilir)) bir sınıfı birden fazla kez kullanabilir.
             * bir hoca derse girdikten sonra 2. derse giremez.
             * 
             */
            bool nameControl = true;
            //tüm sınıflar çağırılabilir, her ders için rastgele bir sınıf denenebilir.
            foreach(string sectionName in database.GetSectionNames())
            {
                if(onePeriod.Name == sectionName)
                {
                    nameControl = false;
                }
            }

            if(nameControl == true)
            {
                foreach (LessonClass lesson in onePeriod.Lessons)    //her bir ders için ayrı atama yapılacağından bir döngüye al.
                {
                    int allClassNumber = allClass.Count();  //tüm sınıfların sayısını al
                    var rand = new Random();    //random tanımla    
                    int randomClass = rand.Next(allClassNumber);    //rastgele bir sınıf almak için rastgele index değeri al
                    var oneClass = allClass[randomClass];   //index değerindeki classı al


                    var minAcademian = new AcademianClass();    //en az müsait olan akademisyen için sonradan değiştirilmek üzere önce boş bir akademisyen oluştur
                    int minAvailable = 50;  //önce max müsaitlik olan 50 den başla

                    foreach (AcademianClass academian in facultyAcademians)     //akademisyenleri döndür
                    {
                        if (academian.academianAvailableTime() < minAvailable)  //eğer bir akademisyen mevcut müsaitlikten daha az müsaitse 
                        {
                            minAvailable = academian.academianAvailableTime();      //o akademisyeni seç ve müsaitlik parametresini güncelle
                            minAcademian = academian;
                        }
                    }

                    bool breakControl = false;

                    for (int j = 0; j < minAcademian.AcademianDates.GetLength(1); j++)  //pazartesi , salı gibi günleri döndür
                    {
                        for (int i = 0; i < minAcademian.AcademianDates.GetLength(0) - 2; i++)    //saatleri döndür.
                        {

                            bool academianBool = minAcademian.AcademianDates[i, j] == true && onePeriod.Dates[i, j].DateavAilability == true &&
                                minAcademian.AcademianDates[i + 1, j] == true && onePeriod.Dates[i + 1, j].DateavAilability == true &&
                                minAcademian.AcademianDates[i + 2, j] == true && onePeriod.Dates[i + 2, j].DateavAilability == true;
                            //akademisyen ve period müsaitliğini kontrol et.

                            bool classbool = oneClass.Dates[i, j] == true && oneClass.Dates[i + 1, j] == true && oneClass.Dates[i + 2, j] == true;
                            //sınıf müsaitliğini kontrol et

                            if (academianBool == true && classbool == true)
                            {
                                minAcademian.AcademianDates[i, j] = false;
                                minAcademian.AcademianDates[i + 1, j] = false;
                                minAcademian.AcademianDates[i + 2, j] = false;
                                //seçili akademisyenin takvimini güncelle

                                minAcademian.AcademianLessonCount++;
                                facultyAcademians.Remove(minAcademian); //akademisyen bir daha seçilmesin diye kaldır.
                                MessageBox.Show("Akademisyen listeden kaldırıldı");


                                oneClass.Dates[i, j] = false;
                                oneClass.Dates[i + 1, j] = false;
                                oneClass.Dates[i + 2, j] = false;
                                //sınıf takvimini güncelle

                                onePeriod.Dates[i, j].DateavAilability = false;
                                onePeriod.Dates[i + 1, j].DateavAilability = false;
                                onePeriod.Dates[i + 2, j].DateavAilability = false;
                                //section takvimini güncelle

                                onePeriod.Dates[i, j].LessonAcademian = minAcademian.AcademianName;
                                onePeriod.Dates[i + 1, j].LessonAcademian = minAcademian.AcademianName;
                                onePeriod.Dates[i + 2, j].LessonAcademian = minAcademian.AcademianName;
                                //section ders akademisyenini ata

                                onePeriod.Dates[i, j].LessonClass = oneClass.Name;
                                onePeriod.Dates[i + 1, j].LessonClass = oneClass.Name;
                                onePeriod.Dates[i + 2, j].LessonClass = oneClass.Name;
                                //class değerini ata

                                onePeriod.Dates[i, j].LessonName = lesson.Name; //ders ismi ata
                                onePeriod.Dates[i + 1, j].LessonName = lesson.Name; //yanlışlıkla class ismine ders ismi eklendi
                                onePeriod.Dates[i + 2, j].LessonName = lesson.Name;
                                

                                MessageBox.Show("bir ders için sınıf - akademisyen - section uyumluluğu başarılı");
                                breakControl = true;
                                break;
                            }

                            //eğer sınıf uygun değilse yeni bir sınıf ata
                            randomClass = rand.Next(allClassNumber);    //rastgele bir sınıf almak için rastgele index değeri al
                            oneClass = allClass[randomClass];   //index değerindeki classı al

                            if (breakControl == true)    //genel döngüden çıkıp sonraki derse geçmesi için
                            {
                                //MessageBox.Show("2. Kontrol Noktası");
                                break;
                            }
                        }
                        if (breakControl == true)    //genel döngüden çıkıp sonraki derse geçmesi için
                        {
                            MessageBox.Show("2- Kontrol Noktası");
                            break;
                        }

                    }
                    minAcademian.UpdateWorkDates(); //akademisyen takvimini database de güncelle
                    oneClass.UpdateClassDates();    //sınıf takvimini database de güncelle
                }

                database.SavePeriodLessonDataToJson(onePeriod); //tüm dersler işlendikten sonra kaydet.
                MessageBox.Show("ders kaydedildi");
            }
            else
            {
                MessageBox.Show($"{onePeriod.Name} isimde bir ders programı oluşturulmuştur");
            }

        }

        
    }
}
