using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Infrastructure.Identity;
using ProjectManager.Infrastructure.Payments;
using ProjectManager.Infrastructure.Pdf;
using ProjectManager.Infrastructure.Persistence;
using ProjectManager.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;

namespace ProjectManager.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging());
        services.AddHostedService<LongRunningService>();
        services.AddSingleton<IBackgroundWorkerQueue, BackgroundWorkerQueue>();
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password = new PasswordOptions
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireUppercase = true,
                RequireNonAlphanumeric = false,
            };
        })
        .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
        .AddRoleManager<RoleManager<IdentityRole>>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultUI()
        .AddDefaultTokenProviders();

        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<IRoleManagerService, RoleManagerService>();
        services.AddScoped<IUserRoleManagerService, UserRoleManagerService>();
        services.AddScoped<IUserManagerService, UserManagerService>();
        services.AddSingleton<IEmail, Email>();
        services.AddSingleton<IAppSettingsService, AppSettingsService>();
        services.AddHttpContextAccessor();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IHttpContext, MyHttpContext>();
        services.AddSingleton<IFileManagerService, FileManagerService>();
        services.AddHttpClient<IPrzelewy24, Przelewy24>();
        services.AddScoped<IQrCodeGenerator, QrCodeGenerator>();
        services.AddScoped<IPdfFileGenerator, RotativaPdfGenerator>();
        services.AddScoped<IRandomService, RandomService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(
        this IApplicationBuilder app,
        IApplicationDbContext context,
        IAppSettingsService appSettingsService,
        IEmail email,
        IWebHostEnvironment webHostEnvironment)
    {
        appSettingsService.Update(context).GetAwaiter().GetResult();
        email.Update(appSettingsService).GetAwaiter().GetResult();

        RotativaConfiguration.Setup(webHostEnvironment.WebRootPath, "Rotativa");

        return app;
    }
}
