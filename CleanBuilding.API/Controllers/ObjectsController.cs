using CleanBuilding.Application.DTOs;
using CleanBuilding.Application.Services;
using CleanBuilding.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanBuilding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectsController : ControllerBase
    {
        private readonly IObjectService _objectService;

        public ObjectsController(IObjectService objectService)
        {
            _objectService = objectService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ObjectDTO>), 200)]
        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                var response = await _objectService.GetObjectData();

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
