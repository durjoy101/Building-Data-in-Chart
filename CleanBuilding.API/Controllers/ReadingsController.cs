using CleanBuilding.Application.DTOs;
using CleanBuilding.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace CleanBuilding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private readonly IReadingService _readService;
        public ReadingsController(IReadingService readingService)
        {
            _readService = readingService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ReadingDTO>), 200)]
        public async Task<IActionResult> GetListAsync(
            int? buidlingID,
            int? objectID,
            int? dataFieldID,
            DateTime startTime,
            DateTime endTime)
        {
            try
            {
                var response = await _readService.GetReadingData(buidlingID, objectID, dataFieldID, startTime, endTime);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
