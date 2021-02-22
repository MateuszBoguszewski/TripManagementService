using System.Threading;
using System.Threading.Tasks;
using Management.Common;
using Management.Trip.Service.Domain;

namespace Management.Trip.Service.Application.Queries.GetAllTrips
{
    public class GetAllTripsQueryHandler : IQueryHandler<GetAllTripsQuery, GetAllTripsQueryResponse>
    {
        private readonly ITripRepository _tripRepository;

        public GetAllTripsQueryHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<GetAllTripsQueryResponse> Handle(GetAllTripsQuery request, CancellationToken cancellationToken)
        {
            var trips = _tripRepository.GetAll();

            return new GetAllTripsQueryResponse(trips.Result);
        }
    }
}
