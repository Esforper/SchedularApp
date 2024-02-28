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
                btn.Text = classes.className + " : " + classes.ClassAvailableTime();
                btn.Click += (s, ev) => {
                    OpenTabControlForClass(classes);
                };

            }

            foreach (onePeriodFacultyClass section in database.AllPeriodLessons)
            {
                Button btn = new Button();
                sectionPanel.Controls.Add(btn);
                btn.Size = sectionDefaultBtn.Size;
                btn.Margin = sectionDefaultBtn.Margin;
                btn.Text = section.PeriodName;
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

                AcademianInfoPageControl academianInfo = new AcademianInfoPageControl(academian.AcademianWorkDates, academian.AcademianName);
                tabPage.Controls.Add(academianInfo);
                academianInfo.Dock = DockStyle.Fill;

            }
            
        }
        private void OpenTabControlForClass(ClassClass class_)
        {

            TabPage tabPage = new TabPage(class_.className);
            if (!IsTabPageAlreadyOpen(tabControl1, class_.className))
            {
                // Oluşturulan TabPage'i TabControl'e ekleyin
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage;

                AcademianInfoPageControl classInfo = new AcademianInfoPageControl(class_.classDates, class_.className);
                tabPage.Controls.Add(classInfo);
                classInfo.Dock = DockStyle.Fill;

            }

        }

        private void OpenTabControlForSection(onePeriodFacultyClass section)
        {

            TabPage tabPage = new TabPage(section.PeriodName);
            if (!IsTabPageAlreadyOpen(tabControl1, section.PeriodName))
            {
                // Oluşturulan TabPage'i TabControl'e ekleyin
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectedTab = tabPage;

                sectionInfoPage sectionInfo = new sectionInfoPage(section.PeriodName);
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

    }
}
