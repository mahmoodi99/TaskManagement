
using Domain;
using Share;
using Share.Dto;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IActivityService
    {
        Task<List<ActivityGetDto>> GetAll();      
        Task<ActivityGetDto> GetById(Guid id);
        IEnumerable<ActivityGetDto> GetActivity(string dto);
        Task<ActivityDto> Insert(ActivityDto activity);
        Task<ActivityDto> Update( ActivityDto activity);
        Task<Activity> Delete(Guid id);
       Task< bool> IsExist(Guid id);
        
    }
}
