using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using first_lab.model;

namespace first_lab
{
    public delegate void FlightEventHandler(object sender, FlightEventArgs e);

    // Определение класса аргументов события для полетов
    public class FlightEventArgs : EventArgs
    {
        //Свойства
        public Plane FlightPlane { get; }
        //Методы
        public FlightEventArgs(Plane flightPlane)
        {
            FlightPlane = flightPlane;
        }
    }
}
