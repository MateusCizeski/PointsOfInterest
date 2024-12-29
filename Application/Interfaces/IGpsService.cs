using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGpsService
    {
        Task<PointOfInterest> CreatePointOfInterest(CreatePointOfInterestDTO dto);
        Task<PointOfInterest?> GetPointOfInterestById(Guid id);
        Task<IEnumerable<PointOfInterest>> GetAllPointsOfInterest(Guid id);
        Task<IEnumerable<PointOfInterest>> GetNearbyPointsOfInterest(int x, int y, int maxDistance);
        Task DeleteById(Guid id);
    }
}
