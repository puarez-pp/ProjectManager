using MediatR;

namespace ProjectManager.Application.Settlements.Commands.DeleteOffer;

public class DeleteOfferCommand: IRequest
{
    public int Id { get; set; }
}
