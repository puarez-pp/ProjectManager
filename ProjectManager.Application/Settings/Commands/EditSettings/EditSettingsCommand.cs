using ProjectManager.Application.Settings.Queries.Dtos;
using MediatR;

namespace ProjectManager.Application.Settings.Commands.EditSettings;
public class EditSettingsCommand : IRequest
{
    public List<SettingsPositionDto> Positions { get; set; } = new List<SettingsPositionDto>();
}
