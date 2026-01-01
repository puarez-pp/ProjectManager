
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
            Content = todo.Content,
            IsCompleted = todo.IsCompleted,
            CreatedDate = todo.CreatedDate,
            FinishDate = todo.FinishDate,
            CompletionDate = todo.CompletionDate,
            UserFrom = todo.UserFrom.ToUserDto().FullName,
            UserTo = todo.UserTo.ToUserDto().FullName,
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
            Content = reply.Content,
            UserId = reply.UserId,
            User = reply.User.ToUserDto().FullName,
            TodoId = reply.TodoId,
            CreatedDate = reply.CreatedDate
        };
    }

}
