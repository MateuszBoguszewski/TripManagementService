using System;
using System.Threading;
using System.Threading.Tasks;
using Management.Common;
using Management.Trip.Service.Domain;
using MediatR;

namespace Management.Trip.Service.Application.Commands.CreateTrip
{
    public class CreateTripCommandHandler : ICommandHandler<CreateTripCommand>
    {
        private readonly ITripRepository _tripRepository;

        public CreateTripCommandHandler(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<Unit> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = new Domain.Trip(Guid.NewGuid(), request.Name, request.StartDate, request.EndDate);

            await _tripRepository.AddAsync(trip);
            await _tripRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
