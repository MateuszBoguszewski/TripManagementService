using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Trip.Service.Domain
{
    public interface ITripRepository
    {
        Task SaveChangesAsync();
        Task AddAsync(Trip trip);
        Task<Trip> GetById(Guid id);
        Task<IEnumerable<Trip>> GetAll();
    }
}
