using CreditApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Shared.Services.Common.Extensions
{
    public static class DataBaseServiceExtension
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext, AppCreditDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DevConnection"),
             x => x.MigrationsAssembly("CreditApp.Api")));
        }
    }
}
