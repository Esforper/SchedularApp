using Faculty_Course_scheduler;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using System.Windows;
using System.Linq;

internal class Database
{
    public List<AcademianClass> AllAcademians;
    public List<ClassClass> AllClasses;
    public List<FacultyClass> AllFaculties;
    public List<onePeriodFacultyClass> AllPeriodLessons;

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

        AllFaculties = LoadFacultyDataFromJson();
        AllClasses = LoadClassDataFromJson();
        AllAcademians = LoadAcademianDataFromJson(); // LoadDataFromJson'dan gelen değeri AllAcademians'a ata
        AllPeriodLessons = LoadLessonPeriodDataFromJson();
    }



    public void SaveAcademianDataToJson(AcademianClass academian)   //akademisyeni databaseye kaydeder
    {
        //akademisyeni akademisyen listesine ekler, bilgilerini json formatına dönüştürür. json dosyasına bilgiyi yazar.
        try
        {
            AllAcademians.Add(academian);   //hali hazırda databasedeki akademisyenler listesine akademisyeni ekle
            string jsonData = JsonConvert.SerializeObject(AllAcademians, Formatting.Indented);  //bilgileri json formatına getir
            File.WriteAllText(jsonAcademianFilePath, jsonData); //bilgileri json dosyasına yaz

            MessageBox.Show("Veritabanına kaydedildi");
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

                MessageBox.Show($"{academianName} başarıyla veritabanından silindi.");
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
    public void saveClass(ClassClass class_)
    {
        AllClasses = LoadClassDataFromJson();

        try
        {
            AllClasses.Add(class_);
            string jsonData = JsonConvert.SerializeObject(AllClasses, Formatting.Indented);
            File.WriteAllText(jsonClassFilePath, jsonData);

            MessageBox.Show("Veritabanına kaydedildi");
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
        var classToDelete = AllClasses.FirstOrDefault(c => c.className == className);

        if (classToDelete != null)
        {
            // Akademisyeni listeden çıkar
            AllClasses.Remove(classToDelete);

            // Güncellenmiş listeyi JSON'a kaydet
            try
            {
                string jsonData = JsonConvert.SerializeObject(AllClasses, Formatting.Indented);
                File.WriteAllText(jsonClassFilePath, jsonData);

                MessageBox.Show($"{className} başarıyla veritabanından silindi.");
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




    //FACULTY DATA
    public List<FacultyClass> LoadFacultyDataFromJson()
    {
        try
        {
            if (File.Exists(jsonFacultyFilePath))
            {
                string jsonData = File.ReadAllText(jsonFacultyFilePath);
                return JsonConvert.DeserializeObject<List<FacultyClass>>(jsonData) ?? new List<FacultyClass>();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }

        return new List<FacultyClass>(); // Hata durumunda boş bir liste döndür
    }
    public void saveFaculty(FacultyClass faculty)
    {
        AllFaculties = LoadFacultyDataFromJson();

        try
        {
            AllFaculties.Add(faculty);
            string jsonData = JsonConvert.SerializeObject(AllFaculties, Formatting.Indented);
            File.WriteAllText(jsonFacultyFilePath, jsonData);

            MessageBox.Show("Veritabanına kaydedildi");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }

    public List<string> getfaculties()
    {
        AllFaculties = LoadFacultyDataFromJson();
        List<string> allfacultyNames = new List<string>();
        foreach(FacultyClass faculty in AllFaculties)
        {
            allfacultyNames.Add(faculty.facultyName);
        }
        return allfacultyNames;
    }


    //PeriodLesson Database 
    public List<onePeriodFacultyClass> LoadLessonPeriodDataFromJson()
    {
        try
        {
            if (File.Exists(jsonPeriodLessonFilePath))
            {
                string jsonData = File.ReadAllText(jsonPeriodLessonFilePath);
                return JsonConvert.DeserializeObject<List<onePeriodFacultyClass>>(jsonData) ?? new List<onePeriodFacultyClass>();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }

        return new List<onePeriodFacultyClass>(); // Hata durumunda boş bir liste döndür
    }

    public void SavePeriodLessonDataToJson(onePeriodFacultyClass onePeriod)   //akademisyeni databaseye kaydeder
    {
        //akademisyeni akademisyen listesine ekler, bilgilerini json formatına dönüştürür. json dosyasına bilgiyi yazar.
        try
        {
            AllPeriodLessons.Add(onePeriod);   //hali hazırda databasedeki akademisyenler listesine akademisyeni ekle
            string jsonData = JsonConvert.SerializeObject(AllPeriodLessons, Formatting.Indented);  //bilgileri json formatına getir
            File.WriteAllText(jsonPeriodLessonFilePath, jsonData); //bilgileri json dosyasına yaz

            MessageBox.Show("Veritabanına kaydedildi");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }

    public onePeriodFacultyClass GetOneSection(string sectionName)
    {
        AllPeriodLessons = LoadLessonPeriodDataFromJson();
        return AllPeriodLessons.First(sec => sec.PeriodName == sectionName);
    }

}
