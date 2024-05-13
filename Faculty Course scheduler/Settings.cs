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
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void resetDatasBtn_Click(object sender, EventArgs e)
        {
            db.setTestData();
        }
    }
}
