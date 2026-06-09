using AutoMapper;
using ProjectManager.Application.Schedules.Queries.GetScheduleDetails;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Schedules.Mappings;

public class ScheduleDetailsProfile : Profile
{
    public ScheduleDetailsProfile()
    {
        CreateMap<Schedule, ScheduleDetailsVm>()
            .ForMember(dest => dest.Stages, opt => opt.MapFrom(src => src.Stages.OrderBy(s => s.Order)))
            .ForMember(dest => dest.CriticalPath, opt => opt.Ignore());

        CreateMap<ScheduleStage, ScheduleStageDetailsVm>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks.OrderBy(t => t.Order)));

        CreateMap<ScheduleTask, ScheduleTaskDetailsVm>()
          .ForMember(dest => dest.IsMilestone, opt => opt.MapFrom(src => src.IsMilestone))
          .ForMember(dest => dest.AssignedUserName, opt => opt.MapFrom(src => src.AssignedUser.UserName))
          .ForMember(dest => dest.PredecessorIds, opt => opt.MapFrom(src => src.Predecessors.Select(p => p.PredecessorTaskId)))
          .ForMember(dest => dest.SuccessorIds, opt => opt.MapFrom(src => src.Dependencies.Select(d => d.SuccessorTaskId)));


    }
}
