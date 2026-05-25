using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;
using ProjectManager.Application.Users.Extensions;

namespace ProjectManager.Application.Plants.Queries.GetPlantsBasic;

public class GetPlantBasicQueryHandler : IRequestHandler<GetPlantBasicQuery, IEnumerable<PlantBasicDto>>
{
    private readonly IUserRoleManagerService _userRoleManagerService;

    public GetPlantBasicQueryHandler(
        IUserRoleManagerService userRoleManagerService)
    {
        _userRoleManagerService = userRoleManagerService;
    }
    public async Task<IEnumerable<PlantBasicDto>> Handle(GetPlantBasicQuery request, CancellationToken cancellationToken)
    {
        var plants = (await _userRoleManagerService
            .GetUsersInRoleAsync(RolesDict.Telemetria))
            .Select(x => x.ToPlantBasicDto())
            .OrderBy(x => x.Email);
        return plants;
    }
}
