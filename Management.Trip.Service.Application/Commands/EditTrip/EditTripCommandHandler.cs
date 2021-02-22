using System.Threading;
using System.Threading.Tasks;
using Management.Common;
using Management.Trip.Service.Domain;
using MediatR;

namespace Management.Trip.Service.Application.Commands.EditTrip
{
    public class EditTripCommandHandler : ICommandHandler<EditTripCommand>
    {
        private readonly ITripRepository _tripRepository;

        public EditTripCommandHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(EditTripCommand request, CancellationToken cancellationToken)
        {
            var trip = _tripRepository.GetById(request.Id);
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                trip.Result.SetName(request.Name);
            }

            if (request.StartDate != null && request.EndDate != null && request.StartDate < request.EndDate)
            {
                trip.Result.SetDates(request.StartDate, request.EndDate);
            }
            
            await _tripRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
