using MediatR;

namespace ProjectManager.Application.Plants.Commands.DeletePlant;

public class DeletePlantCommand : IRequest
{
    public int Id { get; set; }
}
