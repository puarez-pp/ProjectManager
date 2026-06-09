using AutoMapper;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Mappings;

public class ProjectScopeProfile : Profile
{
    public ProjectScopeProfile()
    {
        CreateMap<ProjectScope, ProjectScopeDto>()
            .ForMember(dest => dest.Positions,
                opt => opt.MapFrom(src => src.Positions.OrderBy(p => p.Order)));
    }
}
