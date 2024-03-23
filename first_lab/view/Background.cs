using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_lab.view
{
    public class Background
    {
        public static readonly Color BackColor;
        static Background()
        {
            DateTime now = DateTime.Now;

            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            {
                BackColor = Color.FromArgb(85, 140, 250);
            }
            else
            {
                BackColor = Color.FromArgb(135, 234, 232);
            }
        }
    }
}
