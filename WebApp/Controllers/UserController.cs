using Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using Share.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Domain;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly IUserServive _userServive;
        private readonly IloginUserService _userServivelogin;
        private readonly IGenerateJSONWebToken _generateJSONWebToken;

        public UserController( IUserServive userServive, IloginUserService userServivelogin, IGenerateJSONWebToken generateJSONWebToken)
        {
            _userServive = userServive;
            _userServivelogin = userServivelogin;
            _generateJSONWebToken = generateJSONWebToken;            
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _userServive.GetAll();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var data = await _userServive.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
      
        [HttpGet("userProfile")]
        public async Task<IActionResult> userProfile()
        {
            var Mobile = HttpContext.User.Claims
            .Where(c => c.Type == "MobilePhone")
            .Select(_ => (_.Value))
            .First();

            //var userProfile = await ctx
            //.Users
            ////.Where(c => (c.Id).ToString() == userId)
            //.Where(c => c.Mobile == Mobile)
            //.Select(_ => new UserDto
            //{
            //    Id = _.Id,
            //    Mobile = _.Mobile,
            //    FirstName = _.FirstName,
            //    LastName = _.LastName,
            //    Password = _.Password,
            //}).FirstOrDefaultAsync();

            return Ok(userProfile);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AddUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nationalcode = _userServive.IsExistNationalCode(user.NationalCode);
            if (nationalcode.Result == true)
            {
                return Ok("کاربر با این کد ملی وجود دارد");
            }
            var mobile = _userServive.IsExisMobile(user.Mobile);
            if (mobile.Result == true)
            {
                return Ok("کاربر با این کاربری وجود دارد");
            }
            await _userServive.Insert(user);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDto login)
        {
            var data = await _userServivelogin.CanLogin(login);
            if (data != null)
            {
                var tokenString = _generateJSONWebToken.GenerateJSONWebToken(login.Mobile);
                var claims = new List<Claim>
                   {
                     new Claim(ClaimTypes.MobilePhone, login.Mobile),
                     //new Claim(ClaimTypes., login.Password)
                    };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return Ok(new { token = tokenString });
            }
            else
                return StatusCode(401);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AddUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userServive.Update(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var data = await _userServive.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            await _userServive.Delete(id);
            return Ok(data);
        }
    }
}
