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
            }
        }

        private void OpenTabControlForAcademian(AcademianClass academian)
        {
            
            TabPage tabPage = new TabPage(academian.AcademianName);
            // Oluşturulan TabPage'i TabControl'e ekleyin
            tabControl1.TabPages.Add(tabPage);
        }

    }
}
