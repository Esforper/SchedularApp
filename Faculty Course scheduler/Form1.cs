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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void ıconButton1_Click(object sender, EventArgs e)
		{
			
			informationEntry infoEntyPage = new informationEntry();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(infoEntyPage);
			infoEntyPage.Dock= DockStyle.Fill;
			infoEntyPage.BringToFront();

		}

        private void infoShowBtn_Click(object sender, EventArgs e)
        {
			infoShowControl infoShowPage = new infoShowControl();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(infoShowPage);
			infoShowPage.Dock = DockStyle.Fill;
			infoShowPage.BringToFront();
        }

        private void makeScheduleBtn_Click(object sender, EventArgs e)
        {
            MakeSchedule schedulePage = new MakeSchedule();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(schedulePage);
            schedulePage.Dock = DockStyle.Fill;
            schedulePage.BringToFront();
        }

       

        private void newMakeScheduleBtn_Click(object sender, EventArgs e)
        {
            makeCourseSchedule newSchedulePage = new makeCourseSchedule();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(newSchedulePage);
            newSchedulePage.Dock = DockStyle.Fill;
            newSchedulePage.BringToFront();
        }
    }
}
