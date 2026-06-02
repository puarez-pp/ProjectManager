using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;

namespace ProjectManager.Application.Todos.Commands.EditTodo;
public class EditTodoCommandHandler : IRequestHandler<EditTodoCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;
    private readonly IAppSettingsService _appSettings;
    private readonly IEmail _email;

    public EditTodoCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime,
        IAppSettingsService settingsService,
        IEmail email)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
        _appSettings = settingsService;
        _email = email;
    }
    public async Task<Unit> Handle(EditTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _context
            .Todos
            .FirstOrDefaultAsync(x=>x.Id == request.Id);
        var oldUserToId = todo.UserToId;

        todo.Title = request.Title;
        todo.CompletionDate = request.CompletionDate;
        todo.Body = request.Body;
        todo.UserFromId = _currentUser.UserId;
        todo.UserToId = request.UserToId;
        todo.ProjectId = request.ProjectId;
        todo.IsCompleted = request.IsCompleted;
        var newUserToId = request.UserToId;

        var sendEmail = await _appSettings.Get(SettingsDict.EmailOnNewTodo);

        if (Convert.ToBoolean(sendEmail) && oldUserToId != newUserToId && false)
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
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
