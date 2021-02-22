using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Trip.Service
{
    public class TripStateRepresentation
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TripStateRepresentation(string name, DateTime startDate, DateTime endDate, bool isCanceled)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public TripStateRepresentation()
        {
        }
    }
}
