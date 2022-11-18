using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Share.Dto;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly IActivityService _activityService;

        public SearchController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("{text}")]
        public IActionResult Get([FromRoute] string text)
        {
            var data = _activityService.GetActivity(text);
            if (data == null)
            {
                return Ok("وظیفه ای با این عنوان وجود ندارد");
            }
            return Ok(data);
        }
    }
}
