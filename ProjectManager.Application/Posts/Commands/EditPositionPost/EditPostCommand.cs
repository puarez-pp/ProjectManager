using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Posts.Commands.EditPositionPost;

public class EditPostCommand : IRequest
{
    public int Id { get; set; }
    public int PositionId { get; set; }

    [Required(ErrorMessage = "Pole 'Treść' jest wymagane")]
    [DisplayName("Treść")]
    public string Content { get; set; }
}
