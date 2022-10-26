using AutoMapper;
using Share.Dto;
using Domain;
using FluentValidation;
using System.Globalization;


namespace Services.AutoMapper
{
    public class AutoMapping : Profile
    {
       public AutoMapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, AddUserDto>().ReverseMap();/*BeforeMap((s, d) => d.Password = Security.SecurePasswordHasher.Hash());*/
            CreateMap<Unit, UnitDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<Activity, ActivityGetDto>().ReverseMap();
            CreateMap<Log_Activity, Log_ActivityDto>().ReverseMap().BeforeMap((s, d) => d.DateTime = DateTime.Now);
      
        }
    }
}
