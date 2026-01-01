using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Todos.Commands.AddPost;

public class AddPostCommand:IRequest
{
    [Required(ErrorMessage = "Pole 'Treść' jest wymagane")]
    [DisplayName("Treść")]
    public string Content { get; set; }
    public int TodoId { get; set; }
}
