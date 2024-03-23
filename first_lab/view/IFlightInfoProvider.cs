using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using first_lab.model;

namespace first_lab.view
{
    public interface IFlightInfoProvider
    {
        List<Plane> GetFlightsByFilter(DateTime? time, string destination);

    }
}