using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_lab.model
{
    public class MainModel
    {
        public Plane GenerateObject(string destination, object company, object planeType, string price, DateTime flyDate)
        {
            Plane newPlane;
            Random rand = new Random();
            int number = rand.Next(1000, 9999);
            PlaneCompany selectedcomp = (PlaneCompany)Enum.Parse(typeof(PlaneCompany), company.ToString());
            if (planeType == null)
            {
                newPlane = new Plane(number, selectedcomp);
            }
            else
            {
                PlaneType selectedtype = (PlaneType)Enum.Parse(typeof(PlaneType), planeType.ToString());
                newPlane = new Plane(number, selectedcomp, selectedtype);
                decimal ticket_price = decimal.Parse(price);
                decimal totalCost = newPlane.CalculateTicketPrice(selectedtype, selectedcomp, ref ticket_price);
                newPlane.Price = totalCost;
            }
            newPlane.Destination = destination;
            newPlane.FlyDate = flyDate;
            newPlane.FlightNumber = number;
            return newPlane;
        }
    }
}
