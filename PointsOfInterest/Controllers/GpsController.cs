using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PointsOfInterest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GpsController : ControllerBase
    {
        private readonly IGpsService _gpsService;

        public GpsController(IGpsService gpsService)
        {
            _gpsService = gpsService;
        }

        [HttpGet]
        [Route("Near/x={x}/y={y}/max-distance={dmax}")]
        public async Task<IActionResult> GetNearbyPoints(int x, int y, int dmax)
        {
            var nearbyPois = await _gpsService.GetNearbyPointsOfInterest(x, y, dmax);

            return Ok(nearbyPois);
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllPoints()
        {
            var points = await _gpsService.GetAllPointsOfInterest();

            return Ok(points);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPointOfInterestById(Guid id)
        {
            var poi = await _gpsService.GetPointOfInterestById(id);

            return Ok(poi);
        }

        [HttpPost]
        [Route("Create/Point")]
        public async Task<IActionResult> CreatePoint(CreatePointOfInterestDTO dto)
        {
            var createdPoi = await _gpsService.CreatePointOfInterest(dto);

            return CreatedAtAction(nameof(GetPointOfInterestById), new { id = createdPoi.Id }, createdPoi);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeletePointOfInterest(Guid id)
        {
            await _gpsService.DeleteById(id);

            return NoContent();
        }
    }
}
