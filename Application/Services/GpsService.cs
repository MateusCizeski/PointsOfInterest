using Application.DTOs;
using Application.Interfaces;
using Domain.Core.Intefaces;
using Domain.Entities;

namespace Application.Services
{
    public class GpsService : IGpsService
    {
        private readonly IPointOfInterestRepository _pointOfInterestRepository;

        public GpsService(IPointOfInterestRepository pointOfInterestRepository)
        {
            _pointOfInterestRepository = pointOfInterestRepository;
        }

        public async Task<PointOfInterest> CreatePointOfInterest(CreatePointOfInterestDTO dto)
        {
            PointOfInterest newPoi = new(dto.Name, dto.X, dto.Y);

            var result = await _pointOfInterestRepository.Add(newPoi);

            return result;
        }

        public async Task DeleteById(Guid id)
        {
           var pointEntity = await _pointOfInterestRepository.GetById(id);

            if (pointEntity is null) return;

            await _pointOfInterestRepository.Delete(pointEntity);
        }

        public async Task<IEnumerable<PointOfInterest>> GetAllPointsOfInterest()
        {
            return await _pointOfInterestRepository.GetAllWhere(p => true);
        }

        public async Task<IEnumerable<PointOfInterest>> GetNearbyPointsOfInterest(int x, int y, int maxDistance)
        {
            var points = await GetAllPointsOfInterest();

            List<PointOfInterest> nearbybyPoints = new();

            foreach (var point in points) 
            {
                double distance = Math.Sqrt(Math.Pow(x - point.X, 2) + Math.Pow(y - point.Y, 2));

                if(distance <= maxDistance) nearbybyPoints.Add(point);
            }

            return nearbybyPoints;
        }

        public async Task<PointOfInterest?> GetPointOfInterestById(Guid id)
        {
            return await _pointOfInterestRepository.GetById(id);
        }
    }
}
