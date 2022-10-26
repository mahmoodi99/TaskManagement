using AutoMapper;
using Data;
using Share.Dto;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services.Interface;


namespace Services.EFService
{
    public class RoleService : IRoleService
    {
        private readonly TaskManageContext ctx;
        private readonly IMapper _mapper;
        public RoleService(TaskManageContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            _mapper = mapper;
        }

        public async Task<Role> Delete(Guid id)
        {
            var data = await ctx.Roles.SingleAsync(c => c.Id == id);
            ctx.Remove(data);
            await ctx.SaveChangesAsync();
            return data;
        }

        public IEnumerable<Role> GetAll()
        {
            return ctx.Roles.ToList();
        }

        public async Task<Role> GetById(Guid id)
        {
            return await ctx.Roles.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<RoleDto> Insert(RoleDto role)
        {
            var data = _mapper.Map<Role>(role);

            await ctx.AddAsync(data);
            await ctx.SaveChangesAsync();
            return role;
        }

        public async Task<RoleDto> Update(RoleDto role)
        {
            var data = _mapper.Map<Role>(role);
            ctx.Update(data);
            await ctx.SaveChangesAsync();
            return role;
        }
    }
}
