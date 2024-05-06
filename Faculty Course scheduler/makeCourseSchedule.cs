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
        /// Yapılacaklar / Notlar
        /// sınıf kapasitesi ders koduna göre ayarlanacağı için sınıf sayısını tutma
        /// her bir takvim hücresi için ders kodunu tutsun sadece, ders kodu varsa doldu, yoksa değil şeklinde
        ///     verim açısından da işlevli olur
        /// 
        ///  !!! Alttan alan üstten alan muhabbetinden dolayı, o an o dersi kaç kişi alıyor vs de bakmak gerekebilir yani dersi tanımlarken aslında
        ///  kaç kişinin o dersi aldığını vs girmek gerekebilir
        ///  
        /// (bu kısımlar için belirli bir format olursa otomatik kayıt yaptırmak tabiri caizse şart yoksa sağlam amelelik)
        /// akademisyen, departman, derslikler başta tanımlanarak verim sağlanabilir.
        /// 
        /// All semesterların listeleri önceden tanımlanarak tanımsızlık sorununun önüne geçiliyor çünkü sonuçta liste tanımlı ama boş sadece
        /// 
        /// enrollment 4 gradelik bir bölüm için 4 değer tutacak sadece.
        /// </summary>

        void makeScheduleFunc(string semester)
        {
            int semesterNum =  SemesterToInt(semester);
            //Fall = 0 , Spring = 1 , else = -1

            List<DepartmentClass>AllDepartments = db.AllDepartments;
            //bilgisayar müh, yazılım müh, gibi tüm bölümlerin listesi

            List<AcademianClass> AllAcademians = db.AllAcademians;

            AllDepartments = AllDepartments.OrderBy(department => department.Name).ToList();
            //Alfabetik olarak sıralanacak (bu kısım sıralanması daha sonra ayarlanacak)

            List<ClassClass> AllClasses = new List<ClassClass>(); //bu şekilde tanımlama diğer kısımlara da uygulanabilir.
            AllClasses = db.AllClasses;

            //Tüm semesterClasslar, Grade listeleri şeklinde saklanıyor
            List<SemesterClass>[] AllSemesters = new List<SemesterClass>[6];
            for(int i = 0; i < 6; i++)  //All semester Liste dizisinin Liste sayısı kadar döndür
            {
                List<SemesterClass> listOfSemesters = new List<SemesterClass> ();
                AllSemesters[i] = listOfSemesters;  //Dizi içerisinde Liste tanımlandı
            }

            foreach(DepartmentClass department in AllDepartments)   //department dönme
            {
                for(int i = 0;i< department.numGrades;i++)  //sınıf sayısı kadar dön
                {
                    SemesterClass oneSemester = new SemesterClass();    //semester oluşturma
                    oneSemester.Name = department.Name + "_" + i+1 + "_" + semester;
                    //bölüm + sınıf numarası + dönemi

                    //semester student capacity kaldırılacak
                    //Bu neden böyle demişim bilmiyorum o nedenle ekliyorum
                    oneSemester.StudentCapacity = department.enrollment[i];
                    //enrollment 4 gradelik bir bölüm için 4 değer tutacak sadece.

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
                        if(lesson.isOK == false)
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
                            foreach (ScheduleMapClass info in infos)
                            {
                                DepartmentClass selectedDepartment = AllDepartments.Find(d => d.Name == info.DepartmentName);
                                int studentNumberInMap = selectedDepartment.enrollment[info.Grade];
                                //fall ve spring aynı öğrenci sayısına sahip var sayıldığı için enrollment[info.Grade] yaptım. diğer türlü
                                //enrollment[info.Grade + Fall_Or_Spring] gibi bir şey yapmam gerekebilirdi
                                sumStudentNumber += studentNumberInMap;
                            }


                            ClassClass selectedClassroom = new ClassClass();
                            //Dersliklerin kapasiteleri de kaydedildiği hesaba katılarak class algoritması
                            foreach (ClassClass oneClassRoom in AllClasses)
                            {
                                //if(oneClassRoom.Capacity >= oneSemester.StudentCapacity)  //bunu engelleme sebebim tanımlanan semesterin student capacityi

                                if (oneClassRoom.Capacity >= sumStudentNumber)
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

                                //infos a göre bilgi atamaları
                                // academian tamam
                                // semester tamam


                                List<SemesterClass> selectedSemesterList = new List<SemesterClass>();
                                //ORTAK DERS KONTROL PARAMETRELERİ
                                //TEK BİR SINIF
                                //TEK AKADEMİSYEN
                                //BİRDEN FAZLA SEMESTER TAKVİMİNDE AYNI UYGUN ZAMAN

                                //semester isminden semester seçmeye yarıyor
                                //semester seçme işlemini isim yerine değerlerden de yapabilirdim ama depolama tasarufu olması için bu şekilde yaptım.
                                //SemesterClass selectedSemesterClass = new SemesterClass();
                                foreach (ScheduleMapClass info in infos)
                                {
                                    foreach (List<SemesterClass> listOfSemesters in AllSemesters)
                                    {
                                        foreach (SemesterClass selectedOneSemester in listOfSemesters)
                                        {
                                            if (selectedOneSemester.Name == info.DepartmentName + "_" + (info.Grade + 1) + "_" + IntToSemester(info.Fall_True_Spring_False))
                                            {
                                                //selectedSemesterClass = selectedOneSemester;  //tek bir semester ile her ortak ders yeri yerine, listeye kaydedip
                                                //daha sonra listeden atamaları gerçekleştirilebilir
                                                selectedSemesterList.Add(selectedOneSemester);
                                            }
                                        }
                                    }
                                }

                                for (int x = 0; x < lessonAcademian.Dates.GetLength(1); x++)
                                {
                                    for (int y = 0; y < lessonAcademian.Dates.GetLength(0) - (lessonDuration - 1); y++)
                                    //son ders için kontrol amaçlı (lessonDuration-1) ifadesine yer verildi.
                                    {
                                        // !!! Algoritma patlarsa buraya bak burası biraz sakat
                                        //Academian takvimi ve semester takvim kontrolü
                                        bool academianSemesterClassBool = true;
                                        for (int z = 0; z < lessonDuration; z++)
                                        {
                                            //Akademisyen ve derslik için zaman kontrolü
                                            bool _academian_ClassBool = lessonAcademian.Dates[y + z, x].DateavAilability == true &&
                                                selectedClassroom.Dates[y + z, x].DateavAilability == true;

                                            //Bölümlerin takvimi için uygunluk takcimi
                                            bool boolForInfosSemesters = true;
                                            foreach (SemesterClass selectedOneSemester in selectedSemesterList)
                                            {
                                                if (selectedOneSemester.Dates[y + z, x].DateavAilability == false)
                                                {
                                                    boolForInfosSemesters = false;
                                                }
                                            }

                                            //buradaki elde edilmeye çalışılan 
                                            if (_academian_ClassBool == false || boolForInfosSemesters == false)
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
                                                lessonAcademian.Dates[y + a, x].DateavAilability = false;    //akademisyenin müsaitlik durumunu güncelle
                                                lessonAcademian.Dates[y + a, x].LessonName = lesson.Name;  //akademisyenin dersini ayarla
                                                lessonAcademian.Dates[y + a, x].LessonClass = selectedClassroom.Name;   //akademisyen takviminde sınıfı ayarla
                                                lessonAcademian.Dates[y + a, x].LessonAcademian = null;    //akademisyenin kendi ders programı olacağı için akademisyen değerini atama

                                                //classroom info page için bilgileri ayarla
                                                selectedClassroom.Dates[y + a, x].DateavAilability = false;
                                                selectedClassroom.Dates[y + a, x].LessonName = lesson.Name;
                                                selectedClassroom.Dates[y + a, x].LessonClass = null;
                                                selectedClassroom.Dates[y + a, x].LessonAcademian = lessonAcademian.AcademianName;

                                                //tüm semesterlar için zaman müsaitliği ayarlıyor.
                                                foreach (SemesterClass selectedOneSemester in selectedSemesterList)
                                                {
                                                    selectedOneSemester.Dates[y + a, x].DateavAilability = false;
                                                    selectedOneSemester.Dates[y + a, x].LessonName = lesson.Name;
                                                    selectedOneSemester.Dates[y + a, x].LessonClass = selectedClassroom.Name;
                                                    selectedOneSemester.Dates[y + a, x].LessonAcademian = lessonAcademian.AcademianName;
                                                }


                                            }

                                            lessonAcademian.AcademianLessonCount++;

                                            //isOK ataması ayarlandı
                                            foreach (SemesterClass selectedOneSemester in selectedSemesterList)
                                            {
                                                foreach (LessonClass lessons in selectedOneSemester.Lessons)
                                                {
                                                    lesson.isOK = true;
                                                }
                                            }

                                            //facultyAcademians.Remove(minAcademian); kısmını kullanmaya gerek yok çünkü map ile seçiliyor zaten

                                            // !!! SemesterMapClasstan diğer semesterlarda da atamaları yapılacak
                                        }


                                    }
                                }


                                //Atamalardan önce kontroller sağlanmalı, sonrasında atamalar olmalı,
                                //infos döngüsünü belki kısaltabilirim, kontrolleri genel olarak bir doğruluk olmalı, her saat dönerken bir doğruluk olmalı.

                                // !!! lessonların semesterda lessonların isOK değişkenini true yapmayı unutma


                            }

                            for (int j = 1; j < 2; j++)   //sırf lab için tek sefer dönecek (verimsel olarak sıkıntılı ama kodun düzeni için şimdilik dursun)
                            {
                                // !!! Lablar için türleri ve hangi laba gideceği şeklinde seçenekler olmalı, sadece lab saati yetmiyor.
                            }
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
        string IntToSemester(int semester)
        {
            if(semester == 0)
            {
                return fallRdBtn.Text;
            }else if(semester == 1)
            {
                return springRdBtn.Text;
            }
            else
            {
                MessageBox.Show("IntToSemester çevirme Hatası");
                return "HATA";
                
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
