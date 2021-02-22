using Management.Common;
using System;

namespace Management.Customer.Service.Application.Commands.AssignCustomerToTrip
{
    public class AssignCustomerToTripCommand : ICommand
    {
        public Guid CustomerId { get; }
        public Guid TripId { get; }

        public AssignCustomerToTripCommand(Guid customerId, Guid tripId)
        {
            CustomerId = customerId;
            TripId = tripId;
        }      
    }
}
