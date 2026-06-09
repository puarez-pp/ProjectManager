using ProjectManager.Application.Tools.Queries.GetRents;
using ProjectManager.Application.Tools.Queries.GetTools;
using ProjectManager.Application.Tools.Queries.GetUserRents;
using ProjectManager.Domain.Entities;
using AutoMapper;

namespace ProjectManager.Application.Tools.Mappings;

public class ToolProfile : Profile // Dodano dziedziczenie po AutoMapper.Profile
{
    public ToolProfile()
    {
        // Tool → ToolDto
        CreateMap<Tool, ToolDto>()
            .ForMember(dest => dest.ValidDate,
                opt => opt.MapFrom(src => src.ValidDate ?? DateTime.Today));

        // ToolRent → ToolRentsDto
        CreateMap<ToolRent, ToolRentsDto>()
            .ForMember(dest => dest.User,
                opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Tool.Name));

        // ToolRent → UserRentsDto
        CreateMap<ToolRent, UserRentsDto>()
            .ForMember(dest => dest.ToolName,
                opt => opt.MapFrom(src => src.Tool.Name));
    }
}
