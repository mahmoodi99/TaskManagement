using Domain;
using Share.Dto;


namespace Services.Interface
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Task<Role> GetById(Guid id);
        Task<RoleDto> Insert(RoleDto role);
        Task<RoleDto> Update(RoleDto role);
        Task<Role> Delete(Guid id);
    }
}
