using System.Threading;
using System.Threading.Tasks;
using Management.Common;
using Management.Customer.Service.Domain;
using MediatR;

namespace Management.Customer.Service.Application.Commands.EditCustomer
{
    public class EditCustomerCommandHandler : ICommandHandler<EditCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public EditCustomerCommandHandler(ICustomerRepository tripRepository)
        {
            _customerRepository = tripRepository;
        }

        public async Task<Unit> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.GetById(request.Id);
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                customer.Result.SetName(request.Name);
            }

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                customer.Result.SetPassword(request.Password);
            }

            await _customerRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
