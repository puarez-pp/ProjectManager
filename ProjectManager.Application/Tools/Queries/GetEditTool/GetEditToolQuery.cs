using MediatR;
using ProjectManager.Application.Tools.Commands.EditTool;

namespace ProjectManager.Application.Tools.Queries.GetEditTool;

public class GetEditToolQuery : IRequest<EditToolCommand>
{
    public int Id { get; set; }
}
