using MediatR;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Todos.Commands.AddTodo;

public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;

    public AddTodoCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }   
    public async Task<Unit> Handle(AddTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Domain.Entities.Todo();
        todo.Title = request.Title;
        todo.CompletionDate =  request.CompletionDate;
        todo.Content = request.Content;
        todo.ProjectId = request.ProjectId;
        todo.UserToId = request.UserToId;
        todo.UserFromId = _currentUser.UserId;
        todo.CreatedDate = _dateTime.Now;
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
