using Domain.Core.Intefaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    internal class PointOfInterestRepository : IPointOfInterestRepository
    {
        private readonly ApplicationDbContext _context;

        public PointOfInterestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PointOfInterest> Add(PointOfInterest pointOfInterest)
        {
            var reactionResult = await _context.AddAsync(pointOfInterest);

            await _context.SaveChangesAsync();

            return reactionResult.Entity;
        }

        public async Task Delete(PointOfInterest pointOfInterest)
        {
            _context.PointOfInterest.Remove(pointOfInterest);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetAllWhere(Expression<Func<PointOfInterest, bool>> predicate)
        {
            return await _context.PointOfInterest.ToListAsync();
        }

        public async Task<PointOfInterest> GetById(Guid id)
        {
            return await _context.PointOfInterest.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
