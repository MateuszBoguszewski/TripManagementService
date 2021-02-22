using System;
using Management.Common;


namespace Management.Trip.Service.Application.Commands.CreateTrip
{
    public class CreateTripCommand : ICommand
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CreateTripCommand(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
