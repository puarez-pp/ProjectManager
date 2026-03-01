using ProjectManager.Application.Common.Models;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;


namespace ProjectManager.Application.Users.Queries.GetClientDashboard;
public class GetUserDashboardVm
{
    public string Email { get; set; }
    public PaginatedList<TodoDto> Todos { get; set; }
    
}
