
using ProjectManager.Application.Charts.Queries.Dtos;
using ProjectManager.Application.Common.Models;


namespace ProjectManager.Application.Users.Queries.GetClientDashboard;
public class GetUserDashboardVm
{
    public string Email { get; set; }
    //public PaginatedList<TodoDto> Todos { get; set; }
    public ChartDto TodoCountChart { get; set; }
    public ChartDto TodoCountByProjectChart { get; set; }
}
