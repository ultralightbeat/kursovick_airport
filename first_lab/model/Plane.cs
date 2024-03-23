using first_lab.view;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;
using first_lab.view;

namespace first_lab.model
{
    public class Plane : Transport, ITicketInfoProvider
    {
        //Поля
        public static readonly Color BackColor;

        public Plane(int name_id) : base(name_id) { }
        public string destination { get; set; }
        public string Destination
        {
            get { return destination; }
            set
            {
                char firstChar = value[0];
                if (char.IsLower(firstChar))
                {
                    firstChar = char.ToUpper(firstChar);
                    destination = firstChar + value.Substring(1);
                }
                else
                {
                    destination = value;
                }
            }
        }
        //Свойства
        public DateTime FlyDate { get; set; }
        public int FlightNumber { get; set; }
        public PlaneCompany Comp { get; set; }
        public PlaneType Type { get; set; }
        public float FlightPrice { get; set; }
        public decimal Price { get; set; }
        public override int Name
        {
            get { return FlightNumber; }
            set { FlightNumber = value; }
        }
        //Методы
        public override int IDText()
        {
            return this.Name;
        }
        public override string ToString()
        {
            // Форматируем строку, представляющую объект Plane
            return $"FlightNumber: {FlightNumber}\nDestination: {Destination}\n" +
                   $"Company: {Comp}\nType: {Type}\nFlyDate: {FlyDate}\n" +
                   $"Price: {Price}";
        }
        public static decimal GetPrice(PlaneType type, decimal defaul = 0m)
        {
            switch (type)
            {
                case PlaneType.Passenger:
                    return 100m;
                case PlaneType.Prestige:
                    return 200m;
                case PlaneType.HighSpeed:
                    return 150m;
                default:
                    return default; // Возвращаем нулевую стоимость для неизвестных типов
            }
        }
        public decimal CalculateTicketPrice(PlaneType type, PlaneCompany company, ref decimal ticket_price)
        {
            decimal typePrice = Plane.GetPrice(type);
            decimal companyPrice = Plane.GetPrice(company);

            if (typePrice == 0m || companyPrice == 0m)
            {
                // Обработка ошибки - тип или компания неизвестны
                return 0m;
            }

            // Вычисляем общую стоимость, сложив стоимость типа и компании
            decimal totalCost = typePrice + companyPrice + ticket_price;

            return totalCost;
        }
        public static decimal GetPrice(PlaneCompany company)
        {
            switch (company)
            {
                case PlaneCompany.Aeroflot:
                    return 500m; // Установите стоимость для компании "Aeroflot"
                case PlaneCompany.S7:
                    return 600m; // Установите стоимость для компании "S7"
                case PlaneCompany.Pobeda:
                    return 700m; // Установите стоимость для компании "Pobeda"
                case PlaneCompany.SmartAvia:
                    return 800m; // Установите стоимость для компании "SmartAvia"
                case PlaneCompany.UralAirlines:
                    return 400m; // Установите стоимость для компании "SmartAvia"
                default:
                    return 0m; // Обработка ошибки
            }
        }
        public Plane(int name_id, PlaneCompany company) : base(name_id)
        {
            Comp = company;
        }
        public Plane(int name_id, PlaneCompany company, PlaneType type) : base(name_id)
        {
            Comp = company;
            Type = type;
        }


        // Метод для десериализации объекта из текстовой строки
        public static Plane Deserialize(string serializedData)
        {
            string[] parts = serializedData.Split('|');
            int name_id = int.Parse(parts[0]);
            if (parts.Length == 7)
            {
                Plane plane = new Plane(name_id)
                {
                    FlightNumber = name_id,
                    Destination = parts[1],
                    Comp = (PlaneCompany)Enum.Parse(typeof(PlaneCompany), parts[2]),
                    Type = (PlaneType)Enum.Parse(typeof(PlaneType), parts[3]),
                    //ОАОАОАОАОАА "dd.MM.yyyy H:mm:ss"
                    FlyDate = DateTime.ParseExact(parts[4], "dd.MM.yyyy H:mm:ss", null),
                    foto = parts[5],
                    Price = decimal.Parse(parts[6]),
                };
                return plane;
            }
            return null; // Обработка ошибок десериализации
        }
    }
}


