using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using first_lab.model;
namespace first_lab
{
    public sealed class FlightStatistics
    {
        //Поля
        private static int totalFlights;
        private static decimal totalRevenue;
        //Свойства
        public static int TotalFlights => totalFlights;
        public static decimal TotalRevenue => totalRevenue;
        // События
        public static event FlightEventHandler FlightEvent;
        //Методы
        public static void UpdateStatistics(Plane plane)
        {
            totalFlights++;
            totalRevenue += plane.Price;
            // Запуск события полета
            OnFlightEvent(new FlightEventArgs(plane));
        }
        // Метод для вызова события полета
        private static void OnFlightEvent(FlightEventArgs e)
        {
            FlightEvent?.Invoke(null, e);
        }
        public static void CountFlights(int count)
        {
            totalFlights = count;
        }
        public static void ClearStatistics()
        {
            totalFlights = 0;
            totalRevenue = 0;
        }
        public static string DisplayStatistics()
        {
            string write = "";
            write += ("Flight Statistics:\n");
            write += ($"Total Flights: {TotalFlights}\n");
            write += ($"Total Revenue: {TotalRevenue}\n");
            return write;
        }
    }
}
