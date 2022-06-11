using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.MapProfiles;
using Entities.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories;
using Services;

namespace Api;

public static class ServiceExtensions
{

    public static void Configure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureSqlContext(configuration);
        services.ConfigureWrappers();
        services.ConfigureIdentity();
        services.ConfigureSwagger();
        services.ConfigureCors();
        services.AddEndpointsApiExplorer();
        services.AddControllers();
        services.ConfigureMapper();
    }

    private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetSection("ConnectionString:WhereDb").Value;
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(connection, opt => opt.EnableRetryOnFailure());
            options.EnableSensitiveDataLogging();
        });
    }

    private static void ConfigureWrappers(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IServiceWrapper, ServiceWrapper>();
        services.AddScoped<IUserApplicationRepository, UserApplicationRepository>();
        services.AddScoped<IUserApplicationService, UserApplicationService>();
    }

    private static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<UserApplication, IdentityRole<Guid>>(options =>
        {
            options.Password.RequiredLength = 4;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
        })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();
    }

    private static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1.0 alpha",
                Title = "",
                Description = "",
                Contact = new OpenApiContact
                {
                    Email = "fredvjacobi@gmail.com"
                }
            });
        });
    }

    private static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "corsPolicy",
                builder =>
                {
                    builder.WithOrigins("*");
                });
        });
    }

    private static void ConfigureMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program));
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile(new EventProfile());
            config.AddProfile(new UserApplicationProfile());
        });
        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }
}