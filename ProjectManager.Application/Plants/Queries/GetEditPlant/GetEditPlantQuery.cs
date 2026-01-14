using MediatR;
using ProjectManager.Application.Plants.Commands.EditPlant;

namespace ProjectManager.Application.Plants.Queries.GetEditPlant;

public class GetEditPlantQuery : IRequest<EditPlantCommand>
{
    public int Id { get; set; }
}
