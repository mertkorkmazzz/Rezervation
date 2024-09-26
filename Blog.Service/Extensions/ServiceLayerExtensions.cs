using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();


            services.AddScoped<IRezervationss, Rezervationss>();
            services.AddScoped<ITabless, Tabless>();


            services.AddAutoMapper(assembly);

         

            return services;
        }
    }
}
