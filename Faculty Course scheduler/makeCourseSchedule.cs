using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Course_scheduler
{
    public partial class makeCourseSchedule : UserControl
    {
        Database db = new Database();
        public makeCourseSchedule()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Yapılacaklar
        /// sınıf kapasitesi ders koduna göre ayarlanacağı için sınıf sayısını tutma
        /// her bir takvim hücresi için ders kodunu tutsun sadece, ders kodu varsa doldu, yoksa değil şeklinde
        ///     verim açısından da işlevli olur
        /// 
        ///  !!! Alttan alan üstten alan muhabbetinden dolayı, o an o dersi kaç kişi alıyor vs de bakmak gerekebilir yani dersi tanımlarken aslında
        ///  kaç kişinin o dersi aldığını vs girmek gerekebilir
        ///  
        /// (bu kısımlar için belirli bir format olursa otomatik kayıt yaptırmak tabiri caizse şart yoksa sağlam amelelik)
        /// </summary>

        void makeScheduleFunc(string semester)
        {
            int semesterNum =  SemesterToInt(semester);
            //Fall = 0 , Spring = 1 , else = -1

            //Önce tüm sınıf ve gradeleri tanımlamamız lazım
            //liste şeklinde semesterclass yapabiliriz (listenin listesi ya da listenin dizisi olabilir)

            List<DepartmentClass>AllDepartments = db.AllDepartments;
            //bilgisayar müh, yazılım müh, gibi tüm bölümlerin listesi

            List<AcademianClass> AllAcademians = db.AllAcademians;

            AllDepartments = AllDepartments.OrderBy(department => department.Name).ToList();
            //Alfabetik olarak sıralanacak (bu kısım sıralanması daha sonra ayarlanacak

            List<ClassClass> AllClasses = new List<ClassClass>(); //bu şekilde tanımlama diğer kısımlara da uygulanabilir.
            AllClasses = db.AllClasses;

            //tüm bölümleri tanımlamam lazım
            //departmentlar bilgisayar , yazılım gibi, semester olarak tanımlamam lazım

            List<SemesterClass>[] AllSemesters = new List<SemesterClass>[6];
            for(int i = 0; i < 6; i++)  //All semester Liste dizisinin Liste sayısı kadar döndür
            {
                List<SemesterClass> listOfSemesters = new List<SemesterClass> ();
                AllSemesters[i] = listOfSemesters;  //ilk tanımlamalar
            }


            foreach(DepartmentClass department in AllDepartments)   //department dönme
            {
                for(int i = 0;i< department.numGrades;i++)  //sınıf sayısı kadar dön
                {
                    SemesterClass oneSemester = new SemesterClass();    //semester oluşturma
                    oneSemester.Name = department.Name + "_" + i+1 + "_" + semester;
                    //bölüm + sınıf numarası + dönemi
                    //semester student capacity kaldırılacak
                    oneSemester.FacultyName = department.Name;
                    oneSemester.Lessons = department.courses[department.numGrades+semesterNum];
                    //bu değerlerin kontrolleri sağlanacak
                    AllSemesters[i].Add(oneSemester);
                    
                    //Her departman ve o departmandaki sınıf sayısını döndürdük (yani bil 1.grade , bil 2.grade gibi döndür)
                    //Semester classa (bil 1.sınıf gibi) isim ataması, fakülte ismini, ders listesini ata.
                    // !!! Tüm semesterların listesinin dizisinde , kendi sınıf listesine kaydet
                    //sonuç olarak bil 1. sınıflar 1.sınıfların listesinde, bil 2.sınıf 2.sınıfların listesinde kayıtlı olacak.


                }
            }
            //Bu kısım ön tanımlama, ortak ders saatleri olduğunda olası çakışmaları engellemesi için.

            //Ders programı oluşturmaya geçmeden önce ortak dersleri belirlemek lazım
            //lab saatleri bazen ortak olmayabiliyor. o nedenle T , U düzeyinde bir eşitlik daha doğru olacaktır

            //Akademisyen atamaları için akademisyenin ders kodlarından bulunacak.

            // --- EŞLEŞTİRME AŞAMASI ---
            
            Dictionary<string, List<ScheduleMapClass>> lessonDetails = new Dictionary<string, List<ScheduleMapClass>>();
            
            foreach (DepartmentClass department in AllDepartments) 
            {
                foreach (List<LessonClass> courses in department.courses)
                {
                    foreach (LessonClass lesson in courses)
                    {
                        string lessonCode = lesson.LessonCode;

                        ScheduleMapClass details = new ScheduleMapClass
                        {
                            DepartmentName = department.Name,
                            Grade = courses.IndexOf(lesson) + 1,
                            Fall_True_Spring_False = semesterNum // Burada semester'i nasıl alıyorsanız ona göre ayarlayın
                        };

                        foreach (AcademianClass academian in AllAcademians) //Tüm akademisyenleri döndür
                        {
                            if (academian.lessonCodes.Contains(lessonCode)) //Eğer akademisyen o ders kodunda ders alıyorsa
                            {
                                details.Academian = academian.AcademianName;    //akademisyeni Map yapısına kaydet.
                            }
                        }

                        if (!lessonDetails.ContainsKey(lessonCode)) //eğer içermiyorsa ekle
                        {
                            lessonDetails[lessonCode] = new List<ScheduleMapClass>();
                        }

                        lessonDetails[lessonCode].Add(details); //en son dictionarye Code yi ve ayrıntı bilgileri kaydet
                    }
                }
            }




            //Ana Atamalar bu kısım
            for (int i = 0; i < 6; i++)  //bir bölüm max 6 dönem olabildiğinden 6 var sayılıyor.
            //sınıfları dön
            {
                /*
                foreach(DepartmentClass department in AllDepartments) {  }
                */
                foreach(SemesterClass oneSemester in AllSemesters[i])
                {
                    foreach(LessonClass lesson in oneSemester.Lessons)
                    {
                        //Ders kodları ile akademisyenleri eşleştirmek lazım (tamamlandı)
                        //akademisyen tanımlamasını burada yapmak lazım (map yapısından akademisyen ismi alınarak yapılacak)
                        //eğer ortak bir derslikten ders verilecekse burada derslik tanımlaması yapmak lazım.
                        //eğer teorik ile uygulama dersinin derslikleri farklı oluyorsa derslik ve uygulama kısımları dönerken tanımlama yapmak lazım.
                        
                        // !!! sınıf kapasitelerini de hesaba katarak bu işlemi yapmak gerekebilir

                        // !!! bir ders koduna birkaç semester, bir akademisyen tanımlanırken derslikler tamamen müsaitliğe ve kapasitesine bağlı olarak atama gerçekleştirecek.
                        ClassClass selectedClassroom = new ClassClass();
                        //Dersliklerin kapasiteleri de kaydedildiği hesaba katılarak class algoritması
                        foreach(ClassClass oneClassRoom in AllClasses)
                        {
                            if(oneClassRoom.Capacity >= oneSemester.StudentCapacity)
                            {
                                selectedClassroom = oneClassRoom;
                            }
                        }


                        for(int k = 0; k < 2; k++)  //teorik ve uygulama
                        {
                            //teorik dersi ile uygulama dersi aynı gün olamaz. (verim için de olmamalı.) bu sebeple teorik dersi bir gün seçilirse uygulama dersi başka bir gün seçilmeli.
                            //iki defa haftalık takvim dönülebilir.

                            //ders koduna göre dictionaryi döndürmem gerekecek
                            int lessonDuration = lesson.LessonDuration[k];

                            //map yapısından gerekli bilgileri al.
                            List<ScheduleMapClass> infos = lessonDetails[lesson.LessonCode];
                            //tüm akademisyenlerden akademisyen ismi ile sadece mevcut akademisyeni al.
                            AcademianClass lessonAcademian = AllAcademians.Find(a => a.AcademianName == infos[0].Academian);

                            for (int x = 0; x < lessonAcademian.Dates.GetLength(1); x++)
                            {
                                for (int y = 0; y < lessonAcademian.Dates.GetLength(0) - (lessonDuration-1); y++)
                                //son ders için kontrol amaçlı (lessonDuration-1) ifadesine yer verildi.
                                {
                                    //Academian takvimi ve semester takvim kontrolü
                                    bool academianAndSemesterBool = true;
                                    for (int z = 0; z < lessonDuration; z++)
                                    {
                                        bool _academian_SemesterBool = lessonAcademian.Dates[i, j].DateavAilability == true && oneSemester.Dates[i, j].DateavAilability == true;
                                        if(_academian_SemesterBool == false)
                                        {
                                            academianAndSemesterBool = false;
                                        }
                                    }


                                    bool academianBool =
                                        lessonAcademian.Dates[i, j].DateavAilability == true && oneSemester.Dates[i, j].DateavAilability == true &&
                                        lessonAcademian.Dates[i + 1, j].DateavAilability == true && oneSemester.Dates[i + 1, j].DateavAilability == true &&
                                        lessonAcademian.Dates[i + 2, j].DateavAilability == true && oneSemester.Dates[i + 2, j].DateavAilability == true;



                                }
                            }

                        }

                        for(int j=1;j<2; j++)   //sırf lab için tek sefer dönecek (verimsel olarak sıkıntılı ama kodun düzeni için şimdilik dursun)
                        {

                        }
                    }
                }

            }
            

        }

        int SemesterToInt(string semesterName) {
            if(semesterName == fallRdBtn.Text)
            {
                return 0;
            }
            else if(semesterName == springRdBtn.Text)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string selectedSemester = "";
           if(fallRdBtn.Checked)
            {
                selectedSemester = fallRdBtn.Text;
            }
           else if(springRdBtn.Checked)
            {
                selectedSemester=springRdBtn.Text;
            }
            else
            {
                MessageBox.Show("Bir dönem seçiniz");
            }

           if(selectedSemester != "")
            {
                makeScheduleFunc(selectedSemester);
            }
        }
    }
}
