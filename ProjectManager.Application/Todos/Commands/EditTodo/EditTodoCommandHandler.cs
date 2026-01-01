using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Todos.Commands.EditTodo;
public class EditTodoCommandHandler : IRequestHandler<EditTodoCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;

    public EditTodoCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(EditTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _context
            .Todos
            .FirstOrDefaultAsync(x=>x.Id == request.Id);
        todo.Title = request.Title;
        todo.CompletionDate = request.CompletionDate;
        todo.Content = request.Content;
        todo.UserFromId = _currentUser.UserId;
        todo.UserToId = request.UserToId;
        todo.ProjectId = request.ProjectId;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
