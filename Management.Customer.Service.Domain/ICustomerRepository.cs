using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Customer.Service.Domain
{
    public interface ICustomerRepository
    {
        Task SaveChangesAsync();
        Task AddAsync(Customer customer);
        Task<Customer> GetById(Guid id);
        Task<IEnumerable<Customer>> GetAll();
        Task AssignToTrip(Guid customerId, Guid tripId);
        Task<bool> OverLapCheck(Guid customerId, Guid tripId);
    }
}
