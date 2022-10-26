using Share.Dto;
using Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Services.EFService
{
    public class loginUserService : IloginUserService
    {
        private readonly IUserServive _userServive;
        private readonly ISecurePasswordHasher _securePasswordHasher;
        public loginUserService(IUserServive userServive, ISecurePasswordHasher securePasswordHasher)
        {
            _userServive = userServive;
            _securePasswordHasher = securePasswordHasher;
        }

        public async Task<LoginUserDto> CanLogin(LoginUserDto loginModel)
        {
            var user = await _userServive.FindBy(loginModel.Mobile);
            var password = _securePasswordHasher.Verify(loginModel.Password, user.Password);
            return loginModel;
        }
    }
}
