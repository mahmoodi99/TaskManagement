using Share.Dto;

namespace UI.ServiceHttp
{
    public interface IUserHttpService
    {
        UserDto User { get; }
        Task<List<UserDto>> GetUser();
        Task<UserDto> GetById(string Id);
        Task Insert(UserDto user);
        Task Update(UserDto user);
        Task Delete(Guid Id);
        Task<bool> IsExist(Guid Id);
    }
}
