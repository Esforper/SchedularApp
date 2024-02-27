﻿using System;
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

        onePeriodFacultyClass onePeriod = new onePeriodFacultyClass();    //bilgisayar müh 1. sınıf gibi 

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
            var allAcademians = database.LoadAcademianDataFromJson();
            
            foreach(LessonClass lesoon in onePeriod.Lessons)    //her bir ders için ayrı atama yapılacağından bir döngüye aldım.
            {

                var minAcademian = new AcademianClass();
                int minAvailable = 50;
                foreach (AcademianClass academian in allAcademians)
                {
                    if (academian.academianAvailableTime() < minAvailable)
                    {
                        minAvailable = academian.academianAvailableTime();
                        minAcademian = academian;
                    }
                }




            }

            
        }
    }
}