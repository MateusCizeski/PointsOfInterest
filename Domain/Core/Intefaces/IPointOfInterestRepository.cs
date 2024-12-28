using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Core.Intefaces
{
    public interface IPointOfInterestRepository
    {
        Task<PointOfInterest> Add(PointOfInterest pointOfInterest);
        Task<PointOfInterest> GetById(Guid id);
        Task<IEnumerable<PointOfInterest>> GetAllWhere(Expression<Func<PointOfInterest, bool>> predicate);
        Task Delete(PointOfInterest pointOfInterest);
    }
}
