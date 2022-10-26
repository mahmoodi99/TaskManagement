using AutoMapper;
using Data;
using Share.Dto;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services.Interface;


namespace Services.EFService
{
    public class StatusService : IStatusService
    {
        private readonly TaskManageContext ctx;
        private readonly IMapper _mapper;
        public StatusService(TaskManageContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            _mapper = mapper;
        }
        public async Task<Status> Delete(Guid id)
        {
            var data = await ctx.Statuses.SingleAsync(c => c.Id == id);
            ctx.Remove(data);
            await ctx.SaveChangesAsync();
            return data;
        }
        public IEnumerable<Status> GetAll()
        {
            return ctx.Statuses.ToList();
        }

        public async Task<Status> GetById(Guid id)
        {
            return await ctx.Statuses.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<StatusDto> Insert(StatusDto status)
        {
            var data = _mapper.Map<Status>(status);         
            await ctx.AddAsync(data);
            await ctx.SaveChangesAsync();
            return status;
        }        
        public async Task<StatusDto> Update(StatusDto status)
        {
            var data = _mapper.Map<Status>(status);

            ctx.Update(data);
            await ctx.SaveChangesAsync();
            return status;
        }
    }
}
