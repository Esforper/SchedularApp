using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty_Course_scheduler
{
    internal class ClassClass
    {
        private string className;
        public bool[,] classDates;

        public ClassClass()
        {
            classDates = new bool[10, 5];   //10 satır 5 sütun
        }
    }
}
