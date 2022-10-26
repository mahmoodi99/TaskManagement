using Share.Dto;

namespace UI.ServiceHttp
{
    public interface IActivityHttpService
    {
        Task<List<ActivityGetDto>> GetActivity();
        Task<ActivityGetDto> GetById(string Id);
        Task Insert(ActivityGetDto activity);
        Task Update(ActivityGetDto activity);
        Task Delete(Guid Id);
        Task<bool> IsExist(Guid Id);
    }
}
