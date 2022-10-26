using AutoMapper;
using Data;
using Share.Dto;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services.Interface;


namespace Services.EFService
{

    public class ActivityService : IActivityService
    {

        private readonly TaskManageContext ctx;
        private readonly IMapper _mapper;
        private readonly ILog_Activity ctxlog;
        public ActivityService(TaskManageContext ctx, IMapper mapper, ILog_Activity ctxlog)
        {
            this.ctx = ctx;
            _mapper = mapper;
            this.ctxlog = ctxlog;
        }

        public string Keyword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<Activity> Delete(Guid id)
        {
            var activity = await ctx.Activities.FindAsync(id);
            ctx.Remove(activity);
            await ctx.SaveChangesAsync();
            return activity;
        }

        public IEnumerable<ActivityGetDto> GetActivity(string dto)
        {
            if (dto == null)
            {
                dto = "";
            }
            var lowerSearch = dto.Trim().ToLower();
            var query = ctx.Activities
                .Include(p => p.Unit)
                .Include(p => p.Status)
                .Include(p => p.User).Where(p => p.Title.Contains(lowerSearch))
                .Select(p => new ActivityGetDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    StatusTitle = p.Status.Title,
                    UserFullName = p.User.FirstName + ' ' + p.User.LastName,
                    UnitTitle = p.Unit.title
                }).ToList();
            return (query);
        }

        public  async Task<List<ActivityGetDto>> GetAll()
        {
            return await ctx.Activities
                .Include(x => x.Status)
                .Include(x => x.User)
                .Include(x => x.Unit)
                
             .Select(x=> new ActivityGetDto { 
             Id=x.Id,
             Title = x.Title,
             Description=x.Description,
             StatusTitle = x.Status.Title,
             UserFullName = x.User.FirstName + ' ' + x.User.LastName,
             UnitTitle = x.Unit.title,
             UnitId = x.Unit.Id,
             StatusId = x.Status.Id,
             UserId = x.User.Id
            }).ToListAsync();            
        }       

        public async Task<ActivityGetDto> GetById(Guid id)
        {
            return await ctx.Activities.Select(x => new ActivityGetDto
             {
                 Id = x.Id,
                 Title = x.Title,
                 Description = x.Description,
                UnitId = x.UnitId,
                StatusId = x.StatusId,
                UserId = x.UserId
            }).FirstOrDefaultAsync(x => x.Id == id);             
    }

        

        public async Task<ActivityDto> Insert(ActivityDto activity)
        {
            var data = _mapper.Map<Activity>(activity);
            await ctx.Activities.AddAsync(data);

            var log = new Log_ActivityDto
            {
                ActivityId = data.Id,
                StatusId = activity.StatusId,
                UserID = activity.UserId,
                DateTime = DateTime.Now
            };
            await ctxlog.Insert(log);
            await ctx.SaveChangesAsync();
            return activity;
        }

        public async Task<bool> IsExist(Guid id)
        {
            return await ctx.Activities.AnyAsync(x => x.Id == id);
        }

        public async Task<ActivityDto> Update( ActivityDto activity)
        {
            var status = await ctx.Activities.Where(c => c.Id == activity.Id).AnyAsync(x => x.StatusId == activity.StatusId);
            var data = _mapper.Map<Activity>(activity);

            if (status == false)
            {
                var log = new Log_ActivityDto
                {
                    ActivityId = data.Id,
                    StatusId = activity.StatusId,
                    UserID = activity.UserId,
                    DateTime = DateTime.Now
                };
                await ctxlog.Insert(log);
            }           
            ctx.Update(data);
            await ctx.SaveChangesAsync();
            return activity;
        }
    }
}
