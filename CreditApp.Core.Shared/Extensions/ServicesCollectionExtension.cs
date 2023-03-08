using CreditApp.Core.Contracts;
using CreditApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Shared.Services.Common.Extensions
{
    public static class ServicesCollectionExtension
    {
        public static void SetCommonConfigurations(this IServiceCollection services)
        {
            services.AddTransient<GenericService, GenericService>();
            services.AddTransient<ILoanService, LoanService>();
        }
    }
}
