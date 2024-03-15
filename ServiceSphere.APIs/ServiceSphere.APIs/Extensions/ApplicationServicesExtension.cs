using ServiceSphere.core.Repositeries.contract;
using ServiceSphere.repositery.Data;
using ServiceSphere.repositery;
using ServiceSphere.APIs.Helper;
using ServiceSphere.core.Entities.Services;
using ServiceSphere.core.Services.contract;
using ServiceSphere.services;
using ServiceSphere.core.Entities.Identity;
using ServiceSphere.core.Entities.Users.Freelancer;

namespace ServiceSphere.APIs.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            //allow mapping
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IGenericRepositery<>), typeof(GenericRepositery<>));

          //  services.AddScoped<IGenericRepositeryUsers<Freelancer>, GenericRepositeryUsers<Freelancer>>();

            services.AddScoped(typeof(IGenericRepositeryUsers<>), typeof(GenericRepositeryUsers<>));
           // services.AddScoped<GenericRepositeryUsers<AppUser>>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddScoped(typeof(INotificationService), typeof(NotificationService));

            return services;
        }
    }
}
