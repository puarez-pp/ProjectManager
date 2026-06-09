using AutoMapper;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Mappings;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDto>()
           .ForMember(dest => dest.User,
               opt => opt.MapFrom(src => src.User))
           .ForMember(dest => dest.UserUpd,
               opt => opt.MapFrom(src => src.UserUpdator))
           .ForMember(dest => dest.ProjectManager,
               opt => opt.MapFrom(src => src.UserPM))
           .ForMember(dest => dest.DesignEng,
               opt => opt.MapFrom(src => src.DesignEng))
           .ForMember(dest => dest.ElectricEng,
               opt => opt.MapFrom(src => src.ElectricEng))
           .ForMember(dest => dest.Client,
               opt => opt.MapFrom(src => src.Client.Name))
           .ForMember(dest => dest.ProjectType,
               opt => opt.MapFrom(src => src.ProjectType.ToString()))
           .ForMember(dest => dest.ProjectStatus,
               opt => opt.MapFrom(src => src.Status))
           .ForMember(dest => dest.EditdAt,
               opt => opt.MapFrom(src => src.EditAt))
           .ForMember(dest => dest.Scopes,
               opt => opt.MapFrom(src => src.ProjectScopes.OrderBy(s => s.Order)));

        CreateMap<Project, ProjectBasicsDto>()
            .ForMember(d => d.Client, opt => opt.MapFrom(s => s.Client.Name));
    }
}
