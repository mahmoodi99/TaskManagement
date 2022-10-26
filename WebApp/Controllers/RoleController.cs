using Share.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _roleService.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var data = await _roleService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleDto role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _roleService.Insert(role);
            return Ok(role);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoleDto role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _roleService.Update(role);
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var data = await _roleService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await _roleService.Delete(id);
            return Ok(data);
        }
    }
}
