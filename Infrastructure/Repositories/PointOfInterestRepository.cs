using Domain.Core.Intefaces;
using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class PointOfInterestRepository : IPointOfInterestRepository
    {
        public Task<PointOfInterest> Add(PointOfInterest pointOfInterest)
        {
            throw new NotImplementedException();
        }

        public Task Delete(PointOfInterest pointOfInterest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PointOfInterest>> GetAllWhere(Expression<Func<PointOfInterest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<PointOfInterest> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
