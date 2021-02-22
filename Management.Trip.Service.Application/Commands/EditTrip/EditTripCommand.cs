using System;
using Management.Common;

namespace Management.Trip.Service.Application.Commands.EditTrip
{
    public class EditTripCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EditTripCommand(Guid id, string name, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
