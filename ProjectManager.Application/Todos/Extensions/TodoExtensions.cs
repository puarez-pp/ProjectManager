
using ProjectManager.Application.Todos.Queries.GetProjectTodos;
using ProjectManager.Application.Todos.Queries.GetTodo;
using ProjectManager.Application.Users.Extensions;
using ProjectManager.Domain.Entities;


namespace ProjectManager.Application.Todos.Extensions;
public static class TodoExtensions
{
    public static TodoDto ToTodoDto(this Todo todo)
    {
        if (todo == null)
        {
            return null;
        }
        return new TodoDto
        {
            Id = todo.Id,
            ProjectId = todo.ProjectId,
            Title = todo.Title,
            Body = todo.Body,
            IsCompleted = todo.IsCompleted,
            CreatedAt = todo.CreatedAt,
            FinishDate = todo.FinishDate,
            CompletionDate = todo.CompletionDate,
            UserFrom = todo.UserFrom.ToUserDto(),
            UserTo = todo.UserTo.ToUserDto(),
        };
    }

    public static TodoReplyDto ToTodoReplyDto(this TodoPost reply)
    {
        if (reply == null)
        {
            return null;
        }
        return new TodoReplyDto
        {
            Id = reply.Id,
            Content = reply.Body,
            UserId = reply.UserId,
            User = reply.User.ToUserDto().FullName,
            TodoId = reply.TodoId,
            CreatedAt = reply.CreatedAt
        };
    }

}
