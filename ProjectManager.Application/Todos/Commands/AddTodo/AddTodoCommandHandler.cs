using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Todos.Commands.AddTodo;

public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;
    private readonly IEmail _email;

    public AddTodoCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime,
        IEmail email)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
        _email = email;
    }   
    public async Task<Unit> Handle(AddTodoCommand request, CancellationToken cancellationToken)
    {
        

        var todo = new Todo();
        todo.Title = request.Title;
        todo.CompletionDate =  request.CompletionDate;
        todo.IsCompleted = request.IsCompleted;
        todo.Body = request.Body;
        todo.ProjectId = request.ProjectId;
        todo.UserToId = request.UserToId;
        todo.UserFromId = _currentUser.UserId;
        todo.CreatedAt = _dateTime.Now;
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync(cancellationToken);

        //var settingPosition = await _context.SettingsPositions
        //    .AsNoTracking()
        //    .FirstOrDefaultAsync(x => x.Key == SettingsDict.EmailOnNewTodo);
        //if (bool.Parse(settingPosition.Value))
        //{
        //    await _email.SendAsync(todo.Title,
        //        $"Uzytkownik {todo.UserFrom.FirstName} {todo.UserFrom.LastName} dodał dla Ciebie nowe zadanie o treści: {todo.Body}",
        //        todo.UserTo.Email
        //    );
        //}

        return Unit.Value;
    }
}
