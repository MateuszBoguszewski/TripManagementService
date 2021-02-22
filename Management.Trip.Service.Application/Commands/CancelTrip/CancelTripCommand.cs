using System;
using Management.Common;

namespace Management.Trip.Service.Application.Commands.CancelTrip
{
    public class CancelTripCommand : ICommand
    {
        public Guid Id { get; set; }    

        public CancelTripCommand(Guid id)
        {
            Id = id;
        }
    }
}
