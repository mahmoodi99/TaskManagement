using AutoMapper;
using Data;
using Share.Dto;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using System.Globalization;

namespace Services.EFService
{
    public class Log_ActivityService : ILog_Activity
    {
        private readonly TaskManageContext ctx;
        private readonly IMapper _mapper;
        PersianCalendar pc = new PersianCalendar();
        DateTime thisDate = DateTime.Now;
        public Log_ActivityService(TaskManageContext ctx, IMapper mapper)
        {
             ctx = ctx;
            _mapper = mapper;
        }
       
       public async Task<List<Log_ActivityGetDto>> GetAll()
        {
            
            return await ctx.Log_Activity
                 .Include(x => x.Status)
                 .Include(x => x.User)               
              .Select(x => new Log_ActivityGetDto
              {
                  Id = x.Id,
                  ActivityTitle = x.Activity.Title,
                  StatusTitle = x.Status.Title,
                  DateTime = Convert.ToDateTime( pc.GetYear(x.DateTime) + "/" + pc.GetMonth(x.DateTime) + "/" + pc.GetDayOfMonth(x.DateTime) +"  "+ pc.GetHour(x.DateTime) +":" + pc.GetMinute(x.DateTime)), 
                  UserFullName = x.User.FirstName + " " + x.User.LastName
              }).ToListAsync();
        }

        public async Task<Log_Activity> Delete(Guid id)
        {
            var data = await ctx.Log_Activity.SingleAsync(c => c.Id == id);
            ctx.Remove(data);
            await ctx.SaveChangesAsync();
            return data;
        }

        public async Task<Log_ActivityDto> Insert(Log_ActivityDto log)
        {
            var data = _mapper.Map<Log_Activity>(log);
            await ctx.AddAsync(data);
            await ctx.SaveChangesAsync();
            return log;
        }
        public async Task<Log_ActivityGetDto> GetById(Guid id)
        {
            return await ctx.Log_Activity.Select(x => new Log_ActivityGetDto
            {
                Id = x.Id,
                ActivityId = x.ActivityId,
                UserId = x.UserID,                
                StatusId = x.StatusId,
                DateTime = x.DateTime,

            }).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
