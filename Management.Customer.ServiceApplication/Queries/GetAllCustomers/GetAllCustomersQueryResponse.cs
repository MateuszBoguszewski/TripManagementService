using System;
using System.Collections.Generic;
using System.Text;
using Management.Common;

namespace Management.Customer.Service.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryResponse
    {
        public IEnumerable<Domain.Customer> Customers { get; }

        public GetAllCustomersQueryResponse(IEnumerable<Domain.Customer> customers)
        {
            Customers = customers;
        }
    }
}
