using AutoMapper;
using CitasApp.Dto.Doctor;
using CitasApp.Dto.UserDto;
using CitasApp.Entityes.Doctor;
using CitasApp.Entityes.Users;

namespace CitasApp.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //aca le indico a map q me va comparar 
            CreateMap<UpdateUserDto, UsersEntity>();

            CreateMap<UpdateDoctorDto, DoctorEntity>();
        }
    }
}
