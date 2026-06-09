using AutoMapper;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Mappings;

public class PositionPostProfile : Profile
{
    public PositionPostProfile()
    {
        CreateMap<PositionPost, PositionPostDto>()
            .ForMember(dest => dest.User,
                opt => opt.MapFrom(src => src.User));
    }
}
