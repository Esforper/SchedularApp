using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Course_scheduler.Controller
{
    public partial class InfoPageControl : UserControl
    {
        public InfoPageControl( OneLessonDateClass[,] dateTable,string name)
        {
            InitializeComponent();
            cellColors = new bool[dateTable.GetLength(0),dateTable.GetLength(1)];
            for(int j= 0; j < dateTable.GetLength(1); j++)
            {
                for(int i=0; i < dateTable.GetLength(0); i++)
                {
                    cellColors[i, j] = dateTable[i, j].DateavAilability;
                }
            }

            //cellColors = array_;
            academianNameLabel.Text = name;
        }
        public bool[,] cellColors;

        private void AcademianInfoPageControl_Load(object sender, EventArgs e)
        {
            // Örnek bir bool dizisi oluştur
            int saatControl = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Dock = DockStyle.Fill;
                    label.Text = "Label " + (i*5 +j + 1);

                    label.Text = saatAyarla(saatControl);
                    saatControl++;

                    label.TextAlign = ContentAlignment.MiddleCenter;
                    DateTable.Controls.Add(label, j, i);
                    if (cellColors[i,j]==true) {
                        label.BackColor = Color.Green;
                    }
                    else
                    {
                        label.BackColor = Color.Gray;
                        
                    }
                }
            }
            
        }

        public string saatAyarla(int i)
        {
            int saat = (i / 5) + 8;

            string sonuc = string.Format("{0}.30",saat);
            return sonuc;
        }
    }
}
