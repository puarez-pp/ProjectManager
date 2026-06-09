using AutoMapper;
using ProjectManager.Application.Todos.Queries.GetOverdueTodosForNotification;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Todos.Mappings;

public class TodoProfile : Profile  
{
    public TodoProfile()
    {
        CreateMap<Todo, TodoDto>()
            .ForMember(dest => dest.PostsNumber,
                opt => opt.MapFrom(src => src.TodoPosts.Count))
            .ForMember(dest => dest.UserFrom,
                opt => opt.MapFrom(src => src.UserFrom))
            .ForMember(dest => dest.UserTo,
                opt => opt.MapFrom(src => src.UserTo));

        CreateMap<Todo, OverdueTodoDto>()
            .ForMember(dest => dest.UserToEmail,
                opt => opt.MapFrom(src => src.UserTo.Email));

        CreateMap<TodoPost, TodoPostDto>()
            .ForMember(dest => dest.User,
                opt => opt.MapFrom(src => src.User));
    }
}
