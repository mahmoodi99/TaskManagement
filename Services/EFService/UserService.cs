using AutoMapper;
using Data;
using Share.Dto;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using Microsoft.AspNetCore.Identity;


namespace Services.EFService
{
    public class UserService : IUserServive
    {
        private readonly TaskManageContext ctx;
        private readonly ISecurePasswordHasher _securePasswordHasher;
        private readonly IMapper _mapper;
        public UserService(TaskManageContext ctx, IMapper mapper, ISecurePasswordHasher securePasswordHasher)
        {
            this.ctx = ctx;
            _mapper = mapper;
            _securePasswordHasher = securePasswordHasher;
        }


        public async Task<User> Delete(Guid id)
        {
            var data = await ctx.Users.SingleAsync(c => c.Id == id);
            ctx.Remove(data);
            await ctx.SaveChangesAsync();
            return data;
        }

        public async Task<List<UserDto>> GetAll()
        {
            return await ctx.Users
                 .Include(c => c.Role)

               .Select(c => new UserDto
               {
                   Id = c.Id,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   NationalCode = c.NationalCode,
                   Mobile = c.Mobile,
                   UserName = c.UserName,
                   Password = c.Password,
                   RoleId = c.RoleId,
                   RoleTitle = c.Role.Title,
                   UserFullName = c.FirstName + ' ' + c.LastName

               }).ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
          return  await ctx.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<AddUserDto> Insert(AddUserDto user)
        {
            user.Password = _securePasswordHasher.Hash(user.Password);

            var data = _mapper.Map<User>(user);

            await ctx.AddAsync(data);
            await ctx.SaveChangesAsync();
            return user;
        }

        public async Task<AddUserDto> Update(AddUserDto user)
        {
            var data = _mapper.Map<User>(user);

            ctx.Update(data);
            await ctx.SaveChangesAsync();
            return user;
        }

        public async Task<bool> IsExist(Guid id)
        {
            return await ctx.Users.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> IsExistNationalCode(string nationalcode)
        {
            return await ctx.Users.AnyAsync(x => x.NationalCode == nationalcode);
        }

        public async Task<bool> IsExisMobile(string mobile)
        {
            return await ctx.Users.AnyAsync(x => x.Mobile == mobile);
        }
        public async Task<User?> FindBy(string mobile)
        {
            return await ctx.Users.FirstOrDefaultAsync(x => x.Mobile == mobile);
        }
    }

}
