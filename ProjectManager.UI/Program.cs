using AspNetCore.ReCaptcha;
using DataTables.AspNet.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using NLog.Web;
using ProjectManager.Application;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.AddSettlement;
using ProjectManager.Infrastructure;
using ProjectManager.Infrastructure.Services.SignalR;
using ProjectManager.UI.Extensions;
using ProjectManager.UI.Middlewares;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(LogLevel.Information);
        builder.Logging.AddNLogWeb();

        builder.Services.AddCulture();

        builder.Services.AddSession();

        builder.Services.AddReCaptcha(builder.Configuration.GetSection("ReCaptcha"));

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.RegisterDataTables();


        builder.Services.DefineViewLocation(builder.Configuration);

        builder.Services
            .AddControllersWithViews()
            .AddSessionStateTempDataProvider();


        var app = builder.Build();
        app.UseSession();

        using (var scope = app.Services.CreateScope())
        {
            app.UseRequestLocalization(
                app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.UseInfrastructure(
                scope.ServiceProvider.GetRequiredService<IApplicationDbContext>(),
                app.Services.GetService<IAppSettingsService>(),
                app.Services.GetService<IEmail>(),
                app.Services.GetService<IWebHostEnvironment>());
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        var logger = app.Services.GetService<ILogger<Program>>();

        if (app.Environment.IsDevelopment())
        {
            logger.LogInformation("DEVELOPMENT MODE!!!");
        }
        else
        {
            logger.LogInformation("PRODUCTION MODE!!!");
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        //app.MapHub<NotificationUserHub>("/NotificationUserHub");

        app.MapRazorPages();

        app.Run();
    }
}