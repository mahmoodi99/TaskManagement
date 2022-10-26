using AutoMapper;
using Data;
using Share.Dto;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services.Interface;


namespace Services.EFService
{
    public class UnitService : IUnitService
    {
        private readonly TaskManageContext ctx;
        private readonly IMapper _mapper;
        public UnitService(TaskManageContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            _mapper = mapper;
        }

        public async Task<Unit> Delete(Guid id)
        {
            var data = await ctx.Units.SingleAsync(c => c.Id == id);
            ctx.Remove(data);
            await ctx.SaveChangesAsync();
            return data;
        }

        public IEnumerable<Unit> GetAll()
        {
            return ctx.Units.ToList();
        }

        public async Task<Unit> GetById(Guid id)
        {
            return await ctx.Units.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<UnitDto> Insert(UnitDto unit)
        {
       
            var data = _mapper.Map<Unit>(unit);

            await ctx.AddAsync(data);
            await ctx.SaveChangesAsync();
            return unit;
        }

        public async Task<UnitDto> Update(UnitDto unit)
        {          
            var data = _mapper.Map<Unit>(unit);
            ctx.Update(data);
            await ctx.SaveChangesAsync();
            return unit;
        }
    }
}
