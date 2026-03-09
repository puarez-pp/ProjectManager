using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Options;
using NLog.Web;
using ProjectManager.Application;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Infrastructure;
using WinCCWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Logging.AddNLogWeb();

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddCulture();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();

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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
