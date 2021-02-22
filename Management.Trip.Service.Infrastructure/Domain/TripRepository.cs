using System;
using System.Collections.Generic;
using System.Linq;
using Management.Trip.Service.Infrastructure.DataAccess;
using Management.Trip.Service.Domain;
using System.Threading.Tasks;

namespace Management.Trip.Service.Infrastructure.Domain
{
    public class TripRepository: ITripRepository
    {
        private readonly TripDbContext _dbContext;
        public TripRepository(TripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Service.Domain.Trip trip)
        {
            await _dbContext.Trips.AddAsync(trip);
        }

        public async Task<IEnumerable<Service.Domain.Trip>> GetAll()
        {
            return _dbContext.Trips.Where(t=>t.StartDate > DateTime.Now).ToList();
        }

        public async Task<Service.Domain.Trip> GetById(Guid id)
        {
            return _dbContext.Trips.FirstOrDefault(t => t.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
