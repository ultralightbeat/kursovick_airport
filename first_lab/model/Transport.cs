using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_lab
{
    abstract public class Transport
    {
        //Поля
        private int name_id;
        //Свойства
        public string foto { get; set; }
        public virtual int Name
        {
            get { return name_id; }
            set { name_id = value; }
        }
        public abstract int IDText();

        public Transport(int name_id)
        {
            Name = name_id;
        }
        public virtual decimal CalculateTicketPrice(PlaneType type, PlaneCompany company, ref decimal ticket_price)
        {
            return 0m;
        }

    }
}
