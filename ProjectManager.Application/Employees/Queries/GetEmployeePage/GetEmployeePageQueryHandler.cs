using ProjectManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Employees.Queries.GetEmployeePage;
public class GetEmployeePageQueryHandler : IRequestHandler<GetEmployeePageQuery, Employee1PageDto>
{
    private readonly IApplicationDbContext _context;

    public GetEmployeePageQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Employee1PageDto> Handle(GetEmployeePageQuery request, CancellationToken cancellationToken)
    {
        var employee = await _context
            .Users
            .AsNoTracking()
            .Include(x => x.Employee)
            .Where(x => x.Employee != null)
            .Select(x => new { IsDeleted = x.IsDeleted, Url = x.Employee.WebsiteUrl, Content = x.Employee.WebsiteRaw })
            .FirstOrDefaultAsync(x => !x.IsDeleted && x.Url == request.Url);

        return new Employee1PageDto { Content = employee.Content };
    }
}
