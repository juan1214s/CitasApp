using AutoMapper;
using CitasApp.Dto.UserDto;
using CitasApp.Entityes.Users;

namespace CitasApp.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UpdateUserDto, UsersEntity>();
        }
    }
}
