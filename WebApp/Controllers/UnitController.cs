using Share.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;



namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }


        [HttpGet]
        public IEnumerable<Unit> Get()
        {
            return _unitService.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {            
            var data = await _unitService.GetById(Id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UnitDto unit)      
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _unitService.Insert(unit);
            return Ok(unit);
        }

       
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UnitDto unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            
            await _unitService.Update(unit);
            return Ok(unit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {            
           var data = await _unitService.GetById(Id);
            if (data == null)
            {
                return NotFound();
            }
            await _unitService.Delete(Id);
            return Ok(data);
        }
    }
}
