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
    private readonly IAppSettingsService _appSettings;

    public AddTodoCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime,
        IEmail email,
        IAppSettingsService appSettings)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
        _email = email;
        _appSettings = appSettings;
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

        var sendEmail = await _appSettings.Get(SettingsDict.EmailOnNewTodo);
        
        if (Convert.ToBoolean(sendEmail))
        {
            var todoWithUsers = await _context.Todos
                .Include(x => x.UserFrom)
                .Include(x => x.UserTo)
                .FirstOrDefaultAsync(x => x.Id == todo.Id, cancellationToken);

            await _email.SendAsync(todoWithUsers.Title,
                $"Uzytkownik {todoWithUsers.UserFrom.FirstName} {todoWithUsers.UserFrom.LastName} dodał dla Ciebie nowe zadanie o treści: {todoWithUsers.Body}",
                todoWithUsers.UserTo.Email
            );
        }

        return Unit.Value;
    }
}
