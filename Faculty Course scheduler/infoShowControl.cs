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
                btn.Text = academian.AcademianName;

                btn.Click += (s, ev) => {
                    OpenTabControlForAcademian(academian);
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
