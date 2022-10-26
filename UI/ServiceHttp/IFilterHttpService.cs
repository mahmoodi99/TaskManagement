using Share.Dto;

namespace UI.ServiceHttp
{
    public interface IFilterHttpService
    {
        Task<List<ActivityGetDto>> GetByfilter(string filter);
    }
}
