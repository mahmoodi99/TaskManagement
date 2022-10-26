using Share.Dto;

namespace UI.ServiceHttp
{
    public interface IUnitHttpService
    {
        Task<List<UnitDto>> GetUnit();
        Task<UnitDto> GetById(string Id);
        Task Insert(UnitDto unit);
        Task Update(UnitDto unit);
        Task Delete(Guid Id);
        Task<bool> IsExist(Guid Id);
    }
}
