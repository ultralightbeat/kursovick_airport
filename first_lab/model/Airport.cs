using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using first_lab.model;
using first_lab.view;

namespace first_lab
{
    public class Airport : Transport, IFlightInfoProvider
    {
        //Поля
        public List<Plane> Planes; // Массив для хранения самолетов
        private FlightStatistics flightStatistics;
        private List<Plane> airportPlanes;
        //Свойства
        public FlightStatistics FlightStatisticsInstance => flightStatistics;
        public int id { get; set; }
        public Plane this[int flightNumber]
        {
            get
            {
                return Planes.FirstOrDefault(plane => plane.FlightNumber == flightNumber);
            }
        }
        //Методы
        public Airport(int name_id) : base(name_id)
        {
            Planes = new List<Plane>();
            flightStatistics = new FlightStatistics();
            FlightStatistics.FlightEvent += HandleFlightEvent;
        }
        public Airport(int name_id, List<Plane> existingPlanes) : base(name_id)
        {
            airportPlanes = existingPlanes;
            FlightStatistics.FlightEvent += HandleFlightEvent;
        }
        private void HandleFlightEvent(object sender, FlightEventArgs e)
        {
            // Обработка события полета здесь
            Console.WriteLine($"Add flight with number {e.FlightPlane.FlightNumber} in the airport.");
        }
        public void AddPlane(Plane plane)
        {
            Planes.Add(plane);
            FlightStatistics.UpdateStatistics(plane);
        }
        public override int IDText()
        {
            return this.Name;
        }
        public List<Plane> GetFlightsByFilter(DateTime? time, string destination)
        {
            if (time.HasValue && !string.IsNullOrEmpty(destination))
            {
                // Оба параметра предоставлены
                return Planes.Where(plane => plane.FlyDate > time.Value && plane.Destination == destination).ToList();
            }
            else if (time.HasValue)
            {
                // Только дата предоставлена
                return Planes.Where(plane => plane.FlyDate > time.Value).ToList();
            }
            else if (!string.IsNullOrEmpty(destination))
            {
                // Только пункт назначения предоставлен
                return Planes.Where(plane => plane.Destination == destination).ToList();
            }
            else
            {
                // Нет предоставленных параметров, возвращаем все самолеты
                return Planes.ToList();
            }
        }
    }
}
