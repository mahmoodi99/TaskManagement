using Share.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.EFService;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class log_ActivityController : ControllerBase
    {
        private readonly ILog_Activity _log_Activity;
        public log_ActivityController(ILog_Activity log_Activity)
        {
            _log_Activity = log_Activity;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _log_Activity.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var data = await _log_Activity.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
