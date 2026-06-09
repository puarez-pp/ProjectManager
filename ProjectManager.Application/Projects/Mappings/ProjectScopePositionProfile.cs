using AutoMapper;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Mappings;

public class ProjectScopePositionProfile : Profile
{
    public ProjectScopePositionProfile()
    {
        CreateMap<ProjectScopePosition, ProjectScopePositionDto>();
    }
}
