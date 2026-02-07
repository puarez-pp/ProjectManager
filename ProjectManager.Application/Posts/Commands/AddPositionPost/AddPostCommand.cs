using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Posts.Commands.AddPositionPost;

public class AddPostCommand:IRequest
{

    [Required(ErrorMessage = "Pole 'Treść' jest wymagane")]
    [DisplayName("Treść")]
    public string Body { get; set; }
    public int PositionId { get; set; }
}
