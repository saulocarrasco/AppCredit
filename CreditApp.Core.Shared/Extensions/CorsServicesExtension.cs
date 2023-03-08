using AutoMapper;
using CreditApp.Shared.Services.Common.ProfilesConfig;
using Microsoft.Extensions.DependencyInjection;

namespace CreditApp.Shared.Services.Common.Extensions;

public static class CorsServicesExtension
{
    public static void SetCorsConfiguration(this IServiceCollection services)
    {

        services.AddTransient<IMapper, Mapper>();

        AutoMapperConfig(services);

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });
    }

    private static void AutoMapperConfig(IServiceCollection services)
    {
        IEnumerable<Profile> profiles = new List<Profile>
            {
                new CustomerProfile()
            };

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfiles(profiles);
        });

        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

    }
}

