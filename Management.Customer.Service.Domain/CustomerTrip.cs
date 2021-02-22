using System;

namespace Management.Customer.Service.Domain
{
    public class CustomerTrip
    {
        public Guid CustomerId { get; set; }
        public Customer Customer {get; set;}
        public Guid TripId {get; set;}
        public Trip Trip { get; set; }
    }
}
