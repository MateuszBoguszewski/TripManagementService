using System;
using System.Threading;
using System.Threading.Tasks;
using Management.Common;
using Management.Trip.Service.Domain;
using MediatR;

namespace Management.Trip.Service.Application.Commands.CancelTrip
{
    public class CancelTripCommandHandler : ICommandHandler<CancelTripCommand>
    {
        private readonly ITripRepository _tripRepository;

        public CancelTripCommandHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(CancelTripCommand request, CancellationToken cancellationToken)
        {
            var trip = _tripRepository.GetById(request.Id).Result;

            if (GetBussinesDays(DateTime.Now, trip.StartDate) < 7)
                throw new ArgumentException("Trips can be canceled up to 7 days before the start.");
            
            trip.SetIsCanceled(true);
            await _tripRepository.SaveChangesAsync();

            return Unit.Value;
        }
        
        private int GetBussinesDays(DateTime from, DateTime to)
        {
            var totalBussinesDays = 0;

            for (var date = from; date < to; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday)
                    totalBussinesDays++;
            }

            return totalBussinesDays;
        }
    }
}
