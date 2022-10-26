using Domain;
using Share.Dto;

namespace Services.Interface
{
    public interface IUnitService
    {
        IEnumerable<Unit> GetAll();
        Task<Unit> GetById(Guid id);
        Task<UnitDto> Insert(UnitDto unit);
        Task<UnitDto> Update(UnitDto unit);
        Task<Unit> Delete(Guid id);
    }
}
