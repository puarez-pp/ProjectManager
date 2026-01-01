using MediatR;

namespace ProjectManager.Application.SubContractors.Commands.DeleteSubContractor;

public class DeleteSubContractorCommand:IRequest
{
    public int Id { get; set; }
}
