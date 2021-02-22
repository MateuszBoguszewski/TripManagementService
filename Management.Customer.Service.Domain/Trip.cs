using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Customer.Service.Domain
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCanceled { get; set; }
    }
}
