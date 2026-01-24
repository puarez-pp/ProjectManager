using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Common.Behaviours;
using ProjectManager.Application.Settlements.Commands.AddSettlement;
using System.Reflection;

namespace ProjectManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        return services;
    }
}
