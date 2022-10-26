using Share.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _statusService.GetAll();
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var data = await _statusService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StatusDto status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _statusService.Insert(status);
            return Ok(status);
        }

      
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StatusDto status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _statusService.Update(status);
            return Ok(status);
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        { 
            var data = await _statusService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await _statusService.Delete(id);
            return Ok(data);
        }
    }
}
