using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;
using MediatR;

namespace ProjectManager.Application.Contacts.Commands.SendContactEmail;

public class SendContactEmailCommandHandler : IRequestHandler<SendContactEmailCommand>
{
    private readonly IEmail _email;
    private readonly IAppSettingsService _appSettings;
    private readonly IBackgroundWorkerQueue _backgroundWorkerQueue;

    public SendContactEmailCommandHandler(
        IEmail email,
        IAppSettingsService appSettings,
        IBackgroundWorkerQueue backgroundWorkerQueue)
    {
        _email = email;
        _appSettings = appSettings;
        _backgroundWorkerQueue = backgroundWorkerQueue;
    }

    public async Task<Unit> Handle(SendContactEmailCommand request, CancellationToken cancellationToken)
    {
        var body = $"Nazwa: {request.Name}.<br /></br >E-mail nadawcy: {request.Email}.<br /><br />Tytuł wiadomości: {request.Title}.<br /><br />Wiadomość: {request.Message}.<br /><br />Wysłano z: GymManager.";
        _backgroundWorkerQueue.QueueBackgroundWorkerItem(async x =>
                                                        {
                                                            await _email.SendAsync(
                                                            $"Wiadomość z GymManager: {request.Title}",
                                                            body,
                                                            await _appSettings.Get(SettingsDict.AdminEmail));
                                                        }, $"Kontakt. E-mail: {request.Email}");
        return Unit.Value;
    }
}