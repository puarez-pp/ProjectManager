using MediatR;
using System.ComponentModel;

namespace ProjectManager.Application.Projects.Commands.AddCommentReply;

public class AddCommentReplyCommand : IRequest<int>
{
    public int PostId { get; set; }
    [DisplayName("Treść")]
    public string Content { get; set; }
}
