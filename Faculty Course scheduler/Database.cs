using Faculty_Course_scheduler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

internal class Database
{
    public List<AcademianClass> AllAcademians;
    public List<ClassClass> AllClasses;
    public List<DepartmentClass> AllDepartments;
    public List<SemesterClass> AllSemesterLessons;

    private string folderPath;
    
    private string jsonAcademianFilePath;
    private string jsonClassFilePath;
    private string jsonFacultyFilePath;
    private string jsonPeriodLessonFilePath;

    public Database()
    {
        folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SchedularApp");    //klasör yolu

        //data dosyalarını oluştur
        jsonAcademianFilePath = Path.Combine(folderPath, "academiansData.json");
        jsonClassFilePath = Path.Combine(folderPath, "classesData.json");
        jsonFacultyFilePath = Path.Combine(folderPath, "facultiesData.json");
        jsonPeriodLessonFilePath = Path.Combine(folderPath, "onePeriodLessonsData.json");

        //dosya kontrolleri
        if (!File.Exists(jsonAcademianFilePath))
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        AllDepartments = LoadFacultyDataFromJson();
        AllClasses = LoadClassDataFromJson();
        AllAcademians = LoadAcademianDataFromJson(); // LoadDataFromJson'dan gelen değeri AllAcademians'a ata
        AllSemesterLessons = LoadSemesterDataFromJson();
    }



    public void SaveAcademianDataToJson(AcademianClass academian)   //akademisyeni databaseye kaydeder
    {
        //akademisyeni akademisyen listesine ekler, bilgilerini json formatına dönüştürür. json dosyasına bilgiyi yazar.
        try
        {
            AllAcademians.Add(academian);   //hali hazırda databasedeki akademisyenler listesine akademisyeni ekle
            string jsonData = JsonConvert.SerializeObject(AllAcademians, Formatting.Indented);  //bilgileri json formatına getir
            File.WriteAllText(jsonAcademianFilePath, jsonData); //bilgileri json dosyasına yaz
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }

    public List<AcademianClass> LoadAcademianDataFromJson()
    {
        try
        {
            if (File.Exists(jsonAcademianFilePath))
            {
                string jsonData = File.ReadAllText(jsonAcademianFilePath);
                return JsonConvert.DeserializeObject<List<AcademianClass>>(jsonData) ?? new List<AcademianClass>();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
        return new List<AcademianClass>(); // Hata durumunda boş bir liste döndür
    }

    public void SaveAcademian(AcademianClass academian)
    {
        AllAcademians = LoadAcademianDataFromJson();
        SaveAcademianDataToJson(academian);
    }

    public AcademianClass getOneAcademian(string academianName)
    {
        AllAcademians = LoadAcademianDataFromJson();
        return AllAcademians.FirstOrDefault(academian => academian.AcademianName == academianName);
    }

    public void DeleteAcademian(string academianName)   //Akademisyen silme
    {
        // Akademisyen verilerini JSON'dan yükle
        AllAcademians = LoadAcademianDataFromJson();

        // Silinecek akademisyeni bul
        var academianToDelete = AllAcademians.FirstOrDefault(academian => academian.AcademianName == academianName);

        if (academianToDelete != null)
        {
            // Akademisyeni listeden çıkar
            AllAcademians.Remove(academianToDelete);

            // Güncellenmiş listeyi JSON'a kaydet
            try
            {
                string jsonData = JsonConvert.SerializeObject(AllAcademians, Formatting.Indented);
                File.WriteAllText(jsonAcademianFilePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        else
        {
            MessageBox.Show($"{academianName} isimli akademisyen bulunamadı.");
        }
    }





    //CLASS DATA
    public List<ClassClass> LoadClassDataFromJson()
    {
        try
        {
            if (File.Exists(jsonClassFilePath))
            {
                string jsonData = File.ReadAllText(jsonClassFilePath);
                return JsonConvert.DeserializeObject<List<ClassClass>>(jsonData) ?? new List<ClassClass>();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }

        return new List<ClassClass>(); // Hata durumunda boş bir liste döndür
    }

    public void SaveClass(ClassClass class_)
    {
        AllClasses = LoadClassDataFromJson();

        try
        {
            AllClasses.Add(class_);
            string jsonData = JsonConvert.SerializeObject(AllClasses, Formatting.Indented);
            File.WriteAllText(jsonClassFilePath, jsonData);

            //MessageBox.Show("Veritabanına kaydedildi");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }

    public void DeleteClass(string className)
    {
        // Akademisyen verilerini JSON'dan yükle
        AllClasses = LoadClassDataFromJson();

        // Silinecek akademisyeni bul
        var classToDelete = AllClasses.FirstOrDefault(c => c.Name == className);

        if (classToDelete != null)
        {
            // Akademisyeni listeden çıkar
            AllClasses.Remove(classToDelete);

            // Güncellenmiş listeyi JSON'a kaydet
            try
            {
                string jsonData = JsonConvert.SerializeObject(AllClasses, Formatting.Indented);
                File.WriteAllText(jsonClassFilePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        else
        {
            MessageBox.Show($"{className} isimli akademisyen bulunamadı.");
        }
    }

    public ClassClass GetOneClass(string className_)
    {
        AllClasses = LoadClassDataFromJson();
        return AllClasses.FirstOrDefault(class_ => class_.Name == className_);
    }



    //FACULTY DATA
    public List<DepartmentClass> LoadFacultyDataFromJson()
    {
        try
        {
            if (File.Exists(jsonFacultyFilePath))
            {
                string jsonData = File.ReadAllText(jsonFacultyFilePath);
                return JsonConvert.DeserializeObject<List<DepartmentClass>>(jsonData) ?? new List<DepartmentClass>();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }

        return new List<DepartmentClass>(); // Hata durumunda boş bir liste döndür
    }
    public void SaveDepartment(DepartmentClass faculty)
    {
        AllDepartments = LoadFacultyDataFromJson();

        try
        {
            AllDepartments.Add(faculty);
            string jsonData = JsonConvert.SerializeObject(AllDepartments, Formatting.Indented);
            File.WriteAllText(jsonFacultyFilePath, jsonData);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }

    public List<string> Getfaculties()
    {
        AllDepartments = LoadFacultyDataFromJson();
        List<string> allfacultyNames = new List<string>();
        foreach(DepartmentClass faculty in AllDepartments)
        {
            allfacultyNames.Add(faculty.Name);
        }
        return allfacultyNames;
    }


    //PeriodLesson Database 
    public List<SemesterClass> LoadSemesterDataFromJson()
    {
        try
        {
            if (File.Exists(jsonPeriodLessonFilePath))
            {
                string jsonData = File.ReadAllText(jsonPeriodLessonFilePath);
                return JsonConvert.DeserializeObject<List<SemesterClass>>(jsonData) ?? new List<SemesterClass>();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }

        return new List<SemesterClass>(); // Hata durumunda boş bir liste döndür
    }

    public void SavePeriodLessonDataToJson(SemesterClass onePeriod)   //akademisyeni databaseye kaydeder
    {
        AllSemesterLessons = LoadSemesterDataFromJson();
        //akademisyeni akademisyen listesine ekler, bilgilerini json formatına dönüştürür. json dosyasına bilgiyi yazar.
        try
        {
            AllSemesterLessons.Add(onePeriod);   //hali hazırda databasedeki akademisyenler listesine akademisyeni ekle
            string jsonData = JsonConvert.SerializeObject(AllSemesterLessons, Formatting.Indented);  //bilgileri json formatına getir
            File.WriteAllText(jsonPeriodLessonFilePath, jsonData); //bilgileri json dosyasına yaz

            MessageBox.Show("Section Ders Programı Veritabanına kaydedildi");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }

    public SemesterClass GetOneSection(string sectionName)
    {
        AllSemesterLessons = LoadSemesterDataFromJson();
        return AllSemesterLessons.First(sec => sec.Name == sectionName);
    }
    public List<string> GetSectionNames()
    {
        AllSemesterLessons = LoadSemesterDataFromJson();
        List<string> sectionsNames = new List<string>();
        foreach(SemesterClass section in  AllSemesterLessons)
        {
            sectionsNames.Add(section.Name);
        }
        return sectionsNames;
    }

    public void DeleteSection(SemesterClass section)
    {
        AllSemesterLessons = LoadSemesterDataFromJson();

        List<string> classNames = new List<string>();       //bu kısımlar kaldırılabilir.
        List<string> academianNames = new List<string>();

        ClassClass oneClass = new ClassClass();
        AcademianClass oneAcademian = new AcademianClass();

        for (int j = 0; j < section.Dates.GetLength(1); j++)
        {
            for (int i = 0; i < section.Dates.GetLength(0); i++)
            {
               
                if (section.Dates[i,j].LessonClass != null) //sınıf değeri mevcut olan tarih hücresi
                {
                    oneClass = GetOneClass(section.Dates[i, j].LessonClass);    //sınıf bilgilerini getir.
                    if(oneClass != null)    //sınıf bilgileri mevcut ise
                    {
                        oneClass.Dates[i, j].DateavAilability = true;   //class date hücresi bilgilerini, ders olmayacak şekilde ayarla
                        oneClass.Dates[i, j].LessonAcademian = null;
                        oneClass.Dates[i, j].LessonClass = null;
                        oneClass.Dates[i, j].LessonName = null;
                        oneClass.UpdateClassDates();
                    }
                    

                    oneAcademian = getOneAcademian(section.Dates[i, j].LessonAcademian);
                    if(oneAcademian != null)
                    {
                        oneAcademian.Dates[i, j].DateavAilability = true;
                        oneAcademian.Dates[i, j].LessonAcademian = null;
                        oneAcademian.Dates[i, j].LessonClass = null;
                        oneAcademian.Dates[i, j].LessonName = null;
                        oneAcademian.UpdateWorkDates();
                    }
                    
               
                }

            }
        }
        
       

        // Silinecek akademisyeni bul
        var sectionToDelete = AllSemesterLessons.FirstOrDefault(s => s.Name == section.Name);

        if (sectionToDelete != null)
        {
            // Akademisyeni listeden çıkar
            AllSemesterLessons.Remove(sectionToDelete);

            // Güncellenmiş listeyi JSON'a kaydet
            try
            {
                string jsonData = JsonConvert.SerializeObject(AllSemesterLessons, Formatting.Indented);
                File.WriteAllText(jsonPeriodLessonFilePath, jsonData);

                MessageBox.Show($"{section.Name} başarıyla veritabanından silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        else
        {
            MessageBox.Show($"{section.Name} isimli section bulunamadı.");
        }
    }


}
