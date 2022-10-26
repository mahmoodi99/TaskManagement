using Share.Dto;

namespace UI.ServiceHttp
{
    public interface IRoleHttpService
    {
        Task<List<RoleDto>> GetRole();
        Task<RoleDto> GetById(string Id);
        Task Insert(RoleDto role);
        Task Update(RoleDto role);
        Task Delete(Guid Id);
        Task<bool> IsExist(Guid Id);
    }
}
