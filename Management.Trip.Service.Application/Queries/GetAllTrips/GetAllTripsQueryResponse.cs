using System.Collections.Generic;

namespace Management.Trip.Service.Application.Queries.GetAllTrips
{
    public class GetAllTripsQueryResponse
    {
        public IEnumerable<Domain.Trip> Trips { get; }
        
        public GetAllTripsQueryResponse(IEnumerable<Domain.Trip> trips)
        {
            Trips = trips;
        }
    }
}
