using CitasApp.Services.AutoMapper;
using CitasApp.Services.Doctor;
using CitasApp.Services.Exceptions;
using CitasApp.Services.User;

namespace CitasApp.Services
{
    public static class ServiceRegistration
    {
        //aca registro todos los servicios
        public static void AddCustomService(this IServiceCollection services)
        {
            //AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //Usuarios
            services.AddScoped<CreateUserService>();
            services.AddScoped<DeleteUserService>();
            services.AddScoped<GetUserByIdService>();
            services.AddScoped<UpdateUserService>();

            //Doctor
            services.AddScoped<CreateDoctorService>();
            services.AddScoped<DeleteDoctorService>();
            services.AddScoped<UpdateDoctorService>();
        }
    }
}
