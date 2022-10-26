using Share.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Microsoft.AspNetCore.Cors;

namespace WebApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _activityService.GetAll();
                return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var data = await _activityService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //[HttpGet("text")]
        //public  IActionResult text([FromRoute] string dto)
        //{
        //    var data =  _activityService.GetActivity(dto);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(data);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActivityDto activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           
            await _activityService.Insert(activity);
            return Ok(activity);
        }


        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] ActivityDto activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _activityService.Update(activity);
            return Ok(activity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {           
            var data = await _activityService.GetById(id);

            if (data == null)
            {
                return NotFound();
            }
            await _activityService.Delete(id);

            return Ok(data);
        }
    }
}
