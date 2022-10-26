using Share.Dto;

namespace UI.ServiceHttp
{
    public interface IStatusHttpService
    {
        Task<List<StatusDto>> GetStatus();
        Task<StatusDto>  GetById(string id);    
        Task Insert(StatusDto status);
        Task Update(StatusDto status);
        Task Delete(Guid Id);
    }
}
