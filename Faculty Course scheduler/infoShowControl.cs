using Faculty_Course_scheduler.Controller;
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
    public partial class infoShowControl : UserControl
    {
        public infoShowControl()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
        Database database = new Database();

        private void infoShowControl_Load(object sender, EventArgs e)
        {
            filterComboBox.Items.Add("All Faculties");
            foreach(string facultyName in database.Getfaculties())
            {
                filterComboBox.Items.Add(facultyName);
            }
            filterComboBox.SelectedIndex = 0;
            
            foreach (AcademianClass academian in database.AllAcademians)
            {
                Button btn = new Button();
                academianPanel.Controls.Add(btn);
                btn.Size = defaultBtn.Size;
                btn.Margin = defaultBtn.Margin;
                btn.Text = academian.AcademianName + " : " + academian.academianAvailableTime();

                btn.Click += (s, ev) => {
                    OpenTabControlForAcademian(academian);
                };
            }

            foreach(ClassClass classes in database.AllClasses)
            {
                Button btn = new Button();
                classPanel.Controls.Add(btn);
                btn.Size = defaultBtn.Size;
                btn.Margin = defaultBtn.Margin;
                btn.Text = classes.Name + " : " + classes.ClassAvailableTime();
                btn.Click += (s, ev) => {
                    OpenTabControlForClass(classes);
                };

            }

            foreach (SemesterClass section in database.AllPeriodLessons)
            {
                Button btn = new Button();
                sectionPanel.Controls.Add(btn);
                btn.Size = sectionDefaultBtn.Size;
                btn.Margin = sectionDefaultBtn.Margin;
                btn.Text = section.Name;
                btn.Click += (s, ev) => {
                    OpenTabControlForSection(section);
                };

            }

        }

        private void OpenTabControlForAcademian(AcademianClass academian)
        {
            
            TabPage tabPage = new TabPage(academian.AcademianName);
            if (!IsTabPageAlreadyOpen(tabControl1, academian.AcademianName))
            {
                // Oluşturulan TabPage'i TabControl'e ekleyin
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage;

                AcademianInfoPageControl academianInfo = new AcademianInfoPageControl(academian.AcademianDates, academian.AcademianName);
                tabPage.Controls.Add(academianInfo);
                academianInfo.Dock = DockStyle.Fill;

            }
            
        }
        private void OpenTabControlForClass(ClassClass class_)
        {

            TabPage tabPage = new TabPage(class_.Name);
            if (!IsTabPageAlreadyOpen(tabControl1, class_.Name))
            {
                // Oluşturulan TabPage'i TabControl'e ekleyin
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage;

                AcademianInfoPageControl classInfo = new AcademianInfoPageControl(class_.Dates, class_.Name);
                tabPage.Controls.Add(classInfo);
                classInfo.Dock = DockStyle.Fill;

            }

        }

        private void OpenTabControlForSection(SemesterClass section)
        {

            TabPage tabPage = new TabPage(section.Name);
            if (!IsTabPageAlreadyOpen(tabControl1, section.Name))
            {
                // Oluşturulan TabPage'i TabControl'e ekleyin
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage;

                sectionInfoPage sectionInfo = new sectionInfoPage(section.Name);
                tabPage.Controls.Add(sectionInfo);
                sectionInfo.Dock = DockStyle.Fill;

            }
        }


        private bool IsTabPageAlreadyOpen(TabControl tabControl, string tabName)
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (tabPage.Text == tabName)
                {
                    // İlgili sekme zaten açılmış
                    tabControl.SelectedTab = tabPage; // Açık olan sekme üzerine odaklan
                    return true;
                }
            }
            return false;
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(filterComboBox.SelectedIndex == 0)
            {
                academianPanel.Controls.Clear();
                foreach (AcademianClass academian in database.AllAcademians)
                {
                    Button btn = new Button();
                    academianPanel.Controls.Add(btn);
                    btn.Size = defaultBtn.Size;
                    btn.Margin = defaultBtn.Margin;
                    btn.Text = academian.AcademianName + " : " + academian.academianAvailableTime();

                    btn.Click += (s, ev) => {
                        OpenTabControlForAcademian(academian);
                    };
                }
            }
            else
            {
                var filtedAcademians = database.AllAcademians.FindAll(a => a.AcademianFaculty == filterComboBox.Text);
                academianPanel.Controls.Clear();
                foreach (AcademianClass academian in filtedAcademians)
                {
                    Button btn = new Button();
                    academianPanel.Controls.Add(btn);
                    btn.Size = defaultBtn.Size;
                    btn.Margin = defaultBtn.Margin;
                    btn.Text = academian.AcademianName + " : " + academian.academianAvailableTime();

                    btn.Click += (s, ev) => {
                        OpenTabControlForAcademian(academian);
                    };
                }
            }
            
        }
    }
}
