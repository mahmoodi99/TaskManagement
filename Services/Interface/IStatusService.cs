
using Domain;
using Share.Dto;

namespace Services.Interface
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAll();
        Task<Status> GetById(Guid id);
        Task<StatusDto> Insert(StatusDto status);
        Task<StatusDto> Update(StatusDto status);
        Task<Status> Delete(Guid id);
    
    }
}
