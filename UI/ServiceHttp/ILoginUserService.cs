using Share.Dto;
using System.Threading.Tasks;

namespace UI.ServiceHttp
{
    public interface ILoginUserService
    {
        LoginUserDto User { get; }
        Task Initialize();
        Task<string> login(LoginUserDto login);
        Task<string> Logout();
        Task<(string Message, UserDto? UserProfile)> UserProfileAsync();
    }
}
