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
            foreach (string facultName in database.getfaculties())  //Akademisyenin fakültesini seçerken gerekli
            {
                facultiesComboBox.Items.Add(facultName);
            }

            for(int i = 1; i < 5; i++)
            {
                FacultyClassNumberComboBox.Items.Add(i);
            }
        }

        private void facultiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FacultyClassNumberComboBox.Items.Clear();

            var faculties = database.LoadFacultyDataFromJson();
            var onefaculty = faculties.Where(a => a.facultyName == facultiesComboBox.Text).First();

            for(int i=0;i<onefaculty.facultyClassNumber;i++)
            {
                FacultyClassNumberComboBox.Items.Add(i + 1);
            }

        }

        private void springAutumnComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            findFacultyBtn.Enabled = true;

        }

        onePeriodFacultyClass onePeriod;  //bilgisayar müh 1. sınıf gibi 

        private void findFacultyBtn_Click(object sender, EventArgs e)
        {
            lessonsListBox.Items.Clear();

            string facultyInfo = facultiesComboBox.Text;    //hangi fakülte, bilgisini al.

            string facultyPeriodName = facultyInfo + " - " + FacultyClassNumberComboBox.Text + ". Sınıf" + " - " + springAutumnComboBox.Text + " dönemi";
            labelFacultyClass.Text = facultyPeriodName; //fakülte - sınıf - dönem bilgisi

            int selectedPeriod = springAutumnComboBox.SelectedIndex;
            int selectedClass = Convert.ToInt16(FacultyClassNumberComboBox.Text);

            var allfaculties = database.LoadFacultyDataFromJson();

            var selectedFaculty = allfaculties.Find(a => a.facultyName.Equals(facultiesComboBox.Text));
            int selectedPeriodInt = selectedPeriod + (selectedClass - 1) * 2;   

            var selectedPeriodLessons = selectedFaculty.facultyLessons[selectedPeriodInt];

            onePeriod = new onePeriodFacultyClass();
            onePeriod.Lessons = selectedPeriodLessons;  //yeni oluşturulan period classına dersleri koy.
            onePeriod.PeriodName = facultyPeriodName;   //fakülte - sınıf - dönem bilgisi
            onePeriod.periodFaculty = facultyInfo;      //hangi fakültenin
            onePeriod.periodStudentCapacity = selectedFaculty.facultyStudents;  //öğrenci kapasitesi

            foreach (var lesson in selectedPeriodLessons)
            {
                lessonsListBox.Items.Add(lesson.lessonName);
            }
            
        }

        private void makeScheduleBtn_Click(object sender, EventArgs e)
        {
            var allAcademians = database.LoadAcademianDataFromJson();   //önce tüm akademisyenleri çağır
            var allClass = database.LoadClassDataFromJson();    //tüm sınıfları çağır
            var facultyAcademians = allAcademians.FindAll(a => a.AcademianFaculty == onePeriod.periodFaculty).ToList();
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
                if(onePeriod.PeriodName == sectionName)
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

                    for (int j = 0; j < minAcademian.AcademianWorkDates.GetLength(1); j++)  //pazartesi , salı gibi günleri döndür
                    {
                        for (int i = 0; i < minAcademian.AcademianWorkDates.GetLength(0) - 2; i++)    //saatleri döndür.
                        {

                            bool academianBool = minAcademian.AcademianWorkDates[i, j] == true && onePeriod.facultyLessonDates[i, j].dateavailability == true &&
                                minAcademian.AcademianWorkDates[i + 1, j] == true && onePeriod.facultyLessonDates[i + 1, j].dateavailability == true &&
                                minAcademian.AcademianWorkDates[i + 2, j] == true && onePeriod.facultyLessonDates[i + 2, j].dateavailability == true;
                            //akademisyen ve period müsaitliğini kontrol et.

                            bool classbool = oneClass.classDates[i, j] == true && oneClass.classDates[i + 1, j] == true && oneClass.classDates[i + 2, j] == true;
                            //sınıf müsaitliğini kontrol et

                            if (academianBool == true && classbool == true)
                            {
                                minAcademian.AcademianWorkDates[i, j] = false;
                                minAcademian.AcademianWorkDates[i + 1, j] = false;
                                minAcademian.AcademianWorkDates[i + 2, j] = false;
                                //seçili akademisyenin takvimini güncelle

                                minAcademian.AcademianLessonCount++;
                                facultyAcademians.Remove(minAcademian); //akademisyen bir daha seçilmesin diye kaldır.
                                MessageBox.Show("Akademisyen listeden kaldırıldı");


                                oneClass.classDates[i, j] = false;
                                oneClass.classDates[i + 1, j] = false;
                                oneClass.classDates[i + 2, j] = false;
                                //sınıf takvimini güncelle

                                onePeriod.facultyLessonDates[i, j].dateavailability = false;
                                onePeriod.facultyLessonDates[i + 1, j].dateavailability = false;
                                onePeriod.facultyLessonDates[i + 2, j].dateavailability = false;
                                //section takvimini güncelle

                                onePeriod.facultyLessonDates[i, j].lessonAcademian = minAcademian.AcademianName;
                                onePeriod.facultyLessonDates[i + 1, j].lessonAcademian = minAcademian.AcademianName;
                                onePeriod.facultyLessonDates[i + 2, j].lessonAcademian = minAcademian.AcademianName;
                                //section ders akademisyenini ata

                                onePeriod.facultyLessonDates[i, j].lessonClass = oneClass.className;
                                onePeriod.facultyLessonDates[i + 1, j].lessonClass = oneClass.className;
                                onePeriod.facultyLessonDates[i + 2, j].lessonClass = oneClass.className;
                                //class değerini ata

                                onePeriod.facultyLessonDates[i, j].lessonName = lesson.lessonName; //ders ismi ata
                                onePeriod.facultyLessonDates[i + 1, j].lessonName = lesson.lessonName; //yanlışlıkla class ismine ders ismi eklendi
                                onePeriod.facultyLessonDates[i + 2, j].lessonName = lesson.lessonName;
                                

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
                MessageBox.Show($"{onePeriod.PeriodName} isimde bir ders programı oluşturulmuştur");
            }

        }
    }
}
