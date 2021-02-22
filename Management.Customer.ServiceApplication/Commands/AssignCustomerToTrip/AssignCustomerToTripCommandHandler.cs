using Management.Common;
using Management.Customer.Service.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Management.Customer.Service.Application.Commands.AssignCustomerToTrip
{
    public class AssignCustomerToTripCommandHandler : ICommandHandler<AssignCustomerToTripCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public AssignCustomerToTripCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(AssignCustomerToTripCommand request, CancellationToken cancellationToken)
        {

            if (_customerRepository.OverLapCheck(request.CustomerId, request.TripId).Result)
                throw new ArgumentException("You already have the trip at this time.");

            await _customerRepository.AssignToTrip(request.CustomerId, request.TripId);
            await _customerRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
