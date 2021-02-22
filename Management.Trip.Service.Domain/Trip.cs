using System;

namespace Management.Trip.Service.Domain
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCanceled { get; set; }

        public Trip(Guid id, string name, DateTime startDate, DateTime endDate)
        {
            Id = id;
            SetName(name);
            SetDates(startDate, endDate);
            SetIsCanceled(false);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name of the trip cannot be empty!");

            Name = name;
        }

        public void SetDates(DateTime startDate, DateTime endDate)
        {
            if (startDate == null || endDate == null || startDate > endDate)
                throw new ArgumentException("Dates cannot be empty and end date must be later than start date");

            StartDate = startDate;
            EndDate = endDate;
        }

        public void SetIsCanceled(bool isCanceled)
        {
            IsCanceled = isCanceled;
        }
    }
}
