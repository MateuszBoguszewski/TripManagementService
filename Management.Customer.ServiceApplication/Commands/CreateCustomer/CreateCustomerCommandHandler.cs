using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Management.Common;
using Management.Customer.Service.Domain;
using MediatR;

namespace Management.Customer.Service.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Customer(Guid.NewGuid(), request.Name, request.Password);

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
