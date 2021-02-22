using Management.Customer.Service.Domain;
using Management.Customer.Service.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Customer.Service.Infrastructure.Domain
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;
        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Service.Domain.Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
        }

        public async Task<IEnumerable<Service.Domain.Customer>> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public async Task<Service.Domain.Customer> GetById(Guid id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task AssignToTrip(Guid customerId, Guid tripId)
        {
            await _dbContext.CustomerTrips.AddAsync(new CustomerTrip { CustomerId = customerId, TripId = tripId });
        }

        public async Task<bool> OverLapCheck(Guid customerId, Guid tripId)
        {
            var trip = _dbContext.Trips.FirstOrDefault(t => t.Id == tripId);
            return _dbContext.CustomerTrips.Any(ct => ct.CustomerId == customerId && (ct.Trip.StartDate < trip.EndDate && trip.StartDate < ct.Trip.EndDate));
        }
    }
}
