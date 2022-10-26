using Microsoft.AspNetCore.Mvc;
using Share.Dto;

namespace Services.Interface
{
    public interface IloginUserService
    {
        Task<LoginUserDto> CanLogin(LoginUserDto loginModel);
    }
}
