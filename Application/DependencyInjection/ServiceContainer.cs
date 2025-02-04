using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService
             (this IServiceCollection services)
        {

            #region AddScoped
            //Adcionar as dependecias : AddScoped Service
            #endregion



            return services;
        }
    }
}
