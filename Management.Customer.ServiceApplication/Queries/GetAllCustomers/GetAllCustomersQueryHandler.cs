using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Management.Common;
using Management.Customer.Service.Domain;

namespace Management.Customer.Service.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, GetAllCustomersQueryResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository tripRepository)
        {
            _customerRepository = tripRepository;
        }

        public async Task<GetAllCustomersQueryResponse> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = _customerRepository.GetAll();

            return new GetAllCustomersQueryResponse(customers.Result);
        }
    }
}
