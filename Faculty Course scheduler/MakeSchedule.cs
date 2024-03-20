using System;
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

        SemesterClass oneSection;  //bilgisayar müh 1. sınıf gibi 

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

            oneSection = new SemesterClass();
            oneSection.Lessons = selectedPeriodLessons;  //yeni oluşturulan period classına dersleri koy.
            oneSection.Name = facultyPeriodName;   //fakülte - sınıf - dönem bilgisi
            oneSection.FacultyName = facultyInfo;      //hangi fakültenin
            oneSection.StudentCapacity = selectedFaculty.FacultyNumberOfStudents;  //öğrenci kapasitesi

            foreach (var lesson in selectedPeriodLessons)
            {
                lessonsListBox.Items.Add( lesson.LessonCode + " - " + lesson.Name);
            }
            
        }

        private void makeScheduleBtn_Click(object sender, EventArgs e)
        {
            var allAcademians = database.LoadAcademianDataFromJson();   //önce tüm akademisyenleri çağır
            var allClass = database.LoadClassDataFromJson();    //tüm sınıfları çağır
            var facultyAcademians = allAcademians.FindAll(a => a.AcademianFaculty == oneSection.FacultyName).ToList();
            /** Kurallar
             * Her ders için bir hoca olmalı
             * bir ders bir sınıfta olmalı
             * bir bölüm (bilgisayar müh 1. sınıf (period denebilir)) bir sınıfı birden fazla kez kullanabilir.
             * bir hoca derse girdikten sonra 2. derse giremez.
             * 
             */
            bool nameControl = true;
            //tüm sınıflar çağırılabilir, her ders için rastgele bir sınıf denenebilir.

            //section isim kontrolü
            foreach(string sectionName in database.GetSectionNames())   
            {
                if(oneSection.Name == sectionName)
                {
                    nameControl = false;
                }
            }

            if(nameControl == true)
            {
                progressBar.Minimum = 1;
                progressBar.Maximum = oneSection.Lessons.Count();   //progressbar max uzunluğu
                progressBar.Value = 1;
                progressBar.Step = 1;
                foreach (LessonClass lesson in oneSection.Lessons)    //her bir ders için ayrı atama yapılacağından bir döngüye al.
                {
                    int allClassNumber = allClass.Count();  //tüm sınıfların sayısını al
                    var rand = new Random();    //random tanımla    
                    int randomClass = rand.Next(allClassNumber);    //rastgele bir sınıf almak için rastgele index değeri al
                    var oneClass = allClass[randomClass];   //index değerindeki classı al


                    var minAcademian = new AcademianClass();    //en az müsait olan akademisyen için sonradan değiştirilmek üzere önce boş bir akademisyen oluştur
                    int minAvailable = 50;  //önce max müsaitlik olan 50 den başla

                    foreach (AcademianClass academian in facultyAcademians)     //akademisyenleri döndür
                    {
                        if (academian.academianAvailableTime() <= minAvailable)  //eğer bir akademisyen mevcut müsaitlikten daha az müsaitse 
                        {
                            minAvailable = academian.academianAvailableTime();      //o akademisyeni seç ve müsaitlik parametresini güncelle
                            minAcademian = academian;
                        }
                    }

                    bool breakControl = false;

                    for (int j = 0; j < minAcademian.Dates.GetLength(1); j++)  //pazartesi , salı gibi günleri döndür
                    {
                        for (int i = 0; i < minAcademian.Dates.GetLength(0) - 2; i++)    //saatleri döndür.
                        {

                            bool academianBool = minAcademian.Dates[i, j].DateavAilability == true && oneSection.Dates[i, j].DateavAilability == true &&
                                minAcademian.Dates[i + 1, j].DateavAilability == true && oneSection.Dates[i + 1, j].DateavAilability == true &&
                                minAcademian.Dates[i + 2, j].DateavAilability == true && oneSection.Dates[i + 2, j].DateavAilability == true;
                            //akademisyen ve period müsaitliğini kontrol et.

                            bool classbool = oneClass.Dates[i, j].DateavAilability == true && oneClass.Dates[i + 1, j].DateavAilability == true && oneClass.Dates[i + 2, j].DateavAilability == true;
                            //sınıf müsaitliğini kontrol et

                            if (academianBool == true && classbool == true)
                            {
                                progressBar.PerformStep();  //progressbar ilerlemesini sağla
                                for(int k = 0; k < 3; k++)
                                {
                                    //akademisyen takvimini ayarla
                                    minAcademian.Dates[i+k, j].DateavAilability = false;    //akademisyenin müsaitlik durumunu güncelle
                                    minAcademian.Dates[i + k, j].LessonName = lesson.Name;  //akademisyenin dersini ayarla
                                    minAcademian.Dates[i + k, j].LessonClass = oneClass.Name;   //akademisyen takviminde sınıfı ayarla
                                    minAcademian.Dates[i + k, j].LessonAcademian = null;    //akademisyenin kendi ders programı olacağı için akademisyen değerini atama

                                    //classroom info page için bilgileri ayarla
                                    oneClass.Dates[i + k, j].DateavAilability = false;
                                    oneClass.Dates[i + k, j].LessonName= lesson.Name;
                                    oneClass.Dates[i + k, j].LessonClass = null;
                                    oneClass.Dates[i + k, j].LessonAcademian = minAcademian.AcademianName;

                                    //section bilgilerini ayarla
                                    oneSection.Dates[i + k, j].DateavAilability = false;
                                    oneSection.Dates[i + k, j].LessonName = lesson.Name;
                                    oneSection.Dates[i + k, j].LessonClass = oneClass.Name;
                                    oneSection.Dates[i + k, j].LessonAcademian = minAcademian.AcademianName;
                                }

                                minAcademian.AcademianLessonCount++;
                                facultyAcademians.Remove(minAcademian); //akademisyen bir daha seçilmesin diye kaldır.
                               // MessageBox.Show("Akademisyen listeden kaldırıldı");
                                
                               // MessageBox.Show("bir ders için sınıf - akademisyen - section uyumluluğu başarılı");
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
                           // MessageBox.Show("2- Kontrol Noktası");
                            break;
                        }

                    }
                    minAcademian.UpdateWorkDates(); //akademisyen takvimini database de güncelle
                    oneClass.UpdateClassDates();    //sınıf takvimini database de güncelle
                }

                database.SavePeriodLessonDataToJson(oneSection); //tüm dersler işlendikten sonra kaydet.
                MessageBox.Show("ders programı başarıyla oluşturulmuştur. kaydedildi");
            }
            else
            {
                MessageBox.Show($"{oneSection.Name} isimde bir ders programı daha önce oluşturulmuştur");
            }

        }

    }
}
