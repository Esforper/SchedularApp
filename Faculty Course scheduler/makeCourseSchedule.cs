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
                        
                        List<ScheduleMapClass> infos = lessonDetails[lesson.LessonCode];
                        //infos kısmından seçili semesterların öğrenci sayısı alınarak bir class seçilecek
                        //eğer her ders kodunu girerken öğrenci sayısını girme gibi bir durum olursa girilen öğrenci sayısı sadece 1 semesterın o dersi için
                        //öğrenci sayısına tekabül edecek

                        int sumStudentNumber = 0;
                        foreach(ScheduleMapClass info in infos)
                        {
                            DepartmentClass selectedDepartment = AllDepartments.Find(d => d.Name == info.DepartmentName);
                            int studentNumberInMap = selectedDepartment.enrollment[info.Grade];
                            //fall ve spring aynı öğrenci sayısına sahip var sayıldığı için enrollment[info.Grade] yaptım. diğer türlü
                            //enrollment[info.Grade + Fall_Or_Spring] gibi bir şey yapmam gerekebilirdi
                            sumStudentNumber += studentNumberInMap;
                        }


                        ClassClass selectedClassroom = new ClassClass();
                        //Dersliklerin kapasiteleri de kaydedildiği hesaba katılarak class algoritması
                        foreach(ClassClass oneClassRoom in AllClasses)
                        {
                            //if(oneClassRoom.Capacity >= oneSemester.StudentCapacity)  //bunu engelleme sebebim tanımlanan semesterin student capacityi

                            if(oneClassRoom.Capacity >= sumStudentNumber)
                            {
                                selectedClassroom = oneClassRoom;
                            }
                        }


                        for (int k = 0; k < 2; k++)  //teorik ve uygulama
                        {
                            //teorik dersi ile uygulama dersi aynı gün olamaz. (verim için de olmamalı.) bu sebeple teorik dersi bir gün seçilirse uygulama dersi başka bir gün seçilmeli.
                            //iki defa haftalık takvim dönülebilir.

                            //ders koduna göre dictionaryi döndürmem gerekecek
                            int lessonDuration = lesson.LessonDuration[k];

                            //map yapısından gerekli bilgileri al.
                            
                            //belki ileride infos kısmında bilgiler alınarak atama işlemi kontrol edilebilir.

                            //bir ders koduna yalnız 1 akademisyen atanabildiğinden iki akademisyen değeri de aynı olacaktır. o sebeple infos[0]ı alıyoruz sadece
                            AcademianClass lessonAcademian = AllAcademians.Find(a => a.AcademianName == infos[0].Academian);
                            
                            foreach (ScheduleMapClass info in infos) //
                            {


                                for (int x = 0; x < lessonAcademian.Dates.GetLength(1); x++)
                                {
                                    for (int y = 0; y < lessonAcademian.Dates.GetLength(0) - (lessonDuration - 1); y++)
                                    //son ders için kontrol amaçlı (lessonDuration-1) ifadesine yer verildi.
                                    {
                                        //Academian takvimi ve semester takvim kontrolü
                                        bool academianSemesterClassBool = true;
                                        for (int z = 0; z < lessonDuration; z++)
                                        {
                                            bool _academian_Semester_ClassBool = lessonAcademian.Dates[y, x].DateavAilability == true &&
                                                oneSemester.Dates[y, x].DateavAilability == true &&
                                                selectedClassroom.Dates[y, x].DateavAilability == true;
                                            if (_academian_Semester_ClassBool == false)
                                            {
                                                academianSemesterClassBool = false;
                                            }
                                        }

                                        //bu kısımda saat süresi olarak + - 1 oynama olabilir !!!
                                        bool academianSectionClassLastControl = true;
                                        //akademisyen, semester ve classların son bool değerlerini kontrol et
                                        if (y != lessonAcademian.Dates.GetLength(0) - lessonDuration)
                                        {
                                            // y == saatler , x == günler
                                            //ders süresi 3 saatse, son 2 saat y döngüsünde dönmüyor, sondan 3. saat haricinde kontrol yapıyor.
                                            academianSectionClassLastControl = lessonAcademian.Dates[y + lessonDuration, x].DateavAilability == true &&
                                                oneSemester.Dates[y + lessonDuration, x].DateavAilability == true &&
                                                selectedClassroom.Dates[y + lessonDuration, x].DateavAilability == true;
                                        }

                                        if (academianSemesterClassBool == true && academianSectionClassLastControl == true)
                                        {
                                            for (int a = 0; a < lessonDuration; a++)
                                            {
                                                //akademisyen takvimini ayarla
                                                lessonAcademian.Dates[i + k, j].DateavAilability = false;    //akademisyenin müsaitlik durumunu güncelle
                                                lessonAcademian.Dates[i + k, j].LessonName = lesson.Name;  //akademisyenin dersini ayarla
                                                lessonAcademian.Dates[i + k, j].LessonClass = selectedClassroom.Name;   //akademisyen takviminde sınıfı ayarla
                                                lessonAcademian.Dates[i + k, j].LessonAcademian = null;    //akademisyenin kendi ders programı olacağı için akademisyen değerini atama

                                                //classroom info page için bilgileri ayarla
                                                selectedClassroom.Dates[i + k, j].DateavAilability = false;
                                                selectedClassroom.Dates[i + k, j].LessonName = lesson.Name;
                                                selectedClassroom.Dates[i + k, j].LessonClass = null;
                                                selectedClassroom.Dates[i + k, j].LessonAcademian = lessonAcademian.AcademianName;

                                                //section bilgilerini ayarla
                                                oneSemester.Dates[i + k, j].DateavAilability = false;
                                                oneSemester.Dates[i + k, j].LessonName = lesson.Name;
                                                oneSemester.Dates[i + k, j].LessonClass = selectedClassroom.Name;
                                                oneSemester.Dates[i + k, j].LessonAcademian = lessonAcademian.AcademianName;

                                            }

                                            lessonAcademian.AcademianLessonCount++;
                                            //facultyAcademians.Remove(minAcademian); kısmını kullanmaya gerek yok çünkü map ile seçiliyor zaten

                                            // !!! SemesterMapClasstan diğer semesterlarda da atamaları yapılacak
                                        }


                                    }
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
