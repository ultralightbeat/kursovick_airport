using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_lab.view
{
    public interface ITicketInfoProvider
    {
        decimal CalculateTicketPrice(PlaneType type, PlaneCompany company, ref decimal ticket_price);
    }
}
