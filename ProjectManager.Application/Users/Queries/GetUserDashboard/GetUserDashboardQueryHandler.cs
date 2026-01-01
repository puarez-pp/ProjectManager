using ProjectManager.Application.Charts.Queries.Dtos;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Users.Queries.GetClientDashboard;
public class GetUserDashboardQueryHandler : IRequestHandler<GetUserDashboardQuery, GetUserDashboardVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public GetUserDashboardQueryHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    public async Task<GetUserDashboardVm> Handle(GetUserDashboardQuery request, CancellationToken cancellationToken)
    {
        var vm = new GetUserDashboardVm();

        var user = await GetUser(request);

        vm.Email = user.Email;

        var ticket = GetActiveTodo(user);


        //vm.Todos = await GetTodos(request);

        var color = GetChartColors();
        var borderColors = GetChartBorderColors();

        vm.TodoCountChart = TodoCountChart(color, borderColors);
        vm.TodoCountByProjectChart = TodoCountByProjectChart(color, borderColors);

        return vm;
    }

    private ChartDto TodoCountByProjectChart(List<string> colors, List<string> borderColors)
    {
        int i = 0;

        return new ChartDto
        {
            Positions = new List<ChartPositionDto>
            {
                new ChartPositionDto { Label = "Siłownia", Data = 855, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Crossfit", Data = 600, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Basen", Data = 350, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Aerobik", Data = 100, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Trójbój", Data = 8, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Rower", Data = 444, BorderColor = borderColors[i], Color = colors[i++] },
            }
        };
    }

    private ChartDto TodoCountChart(
        List<string> colors, List<string> borderColors)
    {
        int i = 0;

        return new ChartDto
        {
            Label = "Ilość",
            Positions = new List<ChartPositionDto>
            {
                new ChartPositionDto { Label = "Styczeń", Data = 4, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Luty", Data = 10, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Marzec", Data = 5, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Kwiecień", Data = 6, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Maj", Data = 8, BorderColor = borderColors[i], Color = colors[i++] },
                new ChartPositionDto { Label = "Czerwiec", Data = 14, BorderColor = borderColors[i], Color = colors[i++] },
            }
        };
    }

    private List<string> GetChartBorderColors()
    {
        return new List<string>()
        {
            "rgba(255, 99, 132, 1)",
            "rgba(54, 162, 235, 1)",
            "rgba(255, 206, 86, 1)",
            "rgba(75, 192, 192, 1)",
            "rgba(153, 102, 255, 1)",
            "rgba(255, 159, 64, 1)"
        };
    }

    private List<string> GetChartColors()
    {
        return new List<string>()
        {
            "rgba(255, 99, 132, 0.2)",
            "rgba(54, 162, 235, 0.2)",
            "rgba(255, 206, 86, 0.2)",
            "rgba(75, 192, 192, 0.2)",
            "rgba(153, 102, 255, 0.2)",
            "rgba(255, 159, 64, 0.2)"
        };
    }

    private static DateTime? GetTicketCreatedDate(Todo todo)
    {
        return todo == null ? null : todo.CreatedDate;
    }

    private Todo GetActiveTodo(ApplicationUser user)
    {
        return user.TodosFrom.FirstOrDefault(x =>x.IsCompleted==false);
    }

    private async Task<ApplicationUser> GetUser(GetUserDashboardQuery request)
    {
        return await _context
            .Users
            .Include(x => x.TodosFrom)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId);
    }
}
