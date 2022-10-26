using Domain;
using Share.Dto;

namespace Services.Interface
{
    public interface IUserServive
    {
        Task<List<UserDto>> GetAll();
        Task<User> GetById(Guid id);
        Task<AddUserDto> Insert(AddUserDto user);
        Task<AddUserDto> Update(AddUserDto user);
        Task<User> Delete(Guid id);
        Task<bool> IsExist(Guid id);
        Task<bool> IsExistNationalCode(string nationalcode);
        Task<bool> IsExisMobile(string mobile);
        Task<User?> FindBy(string mobile);

    }
}
