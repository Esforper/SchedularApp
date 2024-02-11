using Faculty_Course_scheduler;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using System.Windows;

internal class Database
{
    public List<AcademianClass> AllAcademians;
    private string folderPath;
    private string jsonFilePath;

    public Database()
    {
        folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SchedularApp");
        jsonFilePath = Path.Combine(folderPath, "academiansData.json");
        if (!File.Exists(jsonFilePath))
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }


        AllAcademians = LoadDataFromJson(); // LoadDataFromJson'dan gelen değeri AllAcademians'a ata
    }

    public void SaveDataToJson(AcademianClass academian)
    {
        try
        {
            AllAcademians.Add(academian);
            string jsonData = JsonConvert.SerializeObject(AllAcademians, Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonData);

            MessageBox.Show("Veritabanına kaydedildi");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }

    public List<AcademianClass> LoadDataFromJson()
    {
        try
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
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
        AllAcademians = LoadDataFromJson();
        SaveDataToJson(academian);
    }
}
