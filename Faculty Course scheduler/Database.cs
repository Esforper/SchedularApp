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

    private string folderPath;
    
    private string jsonAcademianFilePath;
    private string jsonClassFilePath;
    private string jsonFacultyFilePath;

    public Database()
    {
        folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SchedularApp");    //klasör yolu

        //data dosyalarını oluştur
        jsonAcademianFilePath = Path.Combine(folderPath, "academiansData.json");
        jsonClassFilePath = Path.Combine(folderPath, "classesData.json");
        jsonFacultyFilePath = Path.Combine(folderPath, "facultiesData.json");

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
    }



    public void SaveAcademianDataToJson(AcademianClass academian)
    {
        try
        {
            AllAcademians.Add(academian);
            string jsonData = JsonConvert.SerializeObject(AllAcademians, Formatting.Indented);
            File.WriteAllText(jsonAcademianFilePath, jsonData);

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


        
}
