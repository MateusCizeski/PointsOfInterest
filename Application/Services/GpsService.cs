using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class GpsService : IGpsService
    {
        public Task<PointOfInterest> CreatePointOfInterest(CreatePointOfInterestDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PointOfInterest>> GetAllPointsOfInterest(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PointOfInterest>> GetNearbyPointsOfInterest(int x, int y, int maxDistance)
        {
            throw new NotImplementedException();
        }

        public Task<PointOfInterest?> GetPointOfInterestById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
