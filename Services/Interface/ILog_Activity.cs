
using Domain;
using Share.Dto;


namespace Services.Interface
{
    public interface ILog_Activity
    {
        Task<List<Log_ActivityGetDto>> GetAll();
        Task<Log_Activity> Delete(Guid id);
        Task<Log_ActivityDto> Insert(Log_ActivityDto log);
        Task<Log_ActivityGetDto> GetById(Guid id);
    }
}
