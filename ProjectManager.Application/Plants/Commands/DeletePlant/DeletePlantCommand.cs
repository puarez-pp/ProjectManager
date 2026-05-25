using MediatR;

namespace ProjectManager.Application.Plants.Commands.DeletePlant;

public class DeletePlantCommand : IRequest
{
    public string Id { get; set; }
}
