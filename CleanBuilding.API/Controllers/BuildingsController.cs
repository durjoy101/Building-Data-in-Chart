using CleanBuilding.Application.DTOs;
using CleanBuilding.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CleanBuilding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<BuildingDTO>), 200)]
        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                var response = await _buildingService.GetBuildingData();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
