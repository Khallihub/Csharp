using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
            public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
            {

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
       
                return services;
            }

        }
}
