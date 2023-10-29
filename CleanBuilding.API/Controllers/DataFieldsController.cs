using CleanBuilding.Application.DTOs;
using CleanBuilding.Application.Services;
using CleanBuilding.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanBuilding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFieldsController : ControllerBase
    {
        private readonly IDataFieldService _dataFieldService;

        public DataFieldsController(IDataFieldService dataFieldService)
        {
            _dataFieldService = dataFieldService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<DataFieldDTO>), 200)]
        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                var response = await _dataFieldService.GetDataFieldData();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
