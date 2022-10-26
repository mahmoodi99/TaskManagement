using Share.Dto;

namespace UI.ServiceHttp
{
    public interface ILogHttp_ActivityService
    {
        Task<List<Log_ActivityGetDto>> GetLog();
        Task<Log_ActivityGetDto> GetById(string Id);
        Task Delete(Guid Id);
    }
}
