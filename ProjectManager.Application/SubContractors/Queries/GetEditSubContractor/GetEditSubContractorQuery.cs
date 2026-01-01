using MediatR;
using ProjectManager.Application.SubContractors.Commands.EditSubContractor;

namespace ProjectManager.Application.SubContractors.Queries.GetEditSubContractor;

public class GetEditSubContractorQuery:IRequest<EditSubContractorCommand>
{
    public int Id { get; set; }
}
