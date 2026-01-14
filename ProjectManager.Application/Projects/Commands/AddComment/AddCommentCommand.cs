using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Projects.Commands.AddComment;

public class AddCommentCommand : IRequest<int>
{
    public int ProjectId { get; set; }

    [Required(ErrorMessage = "Pole 'Tytuł' jest wymagane")]
    [DisplayName("Tytuł")]
    public string Title { get; set; }
    [DisplayName("Treść")]
    public string Content { get; set; }
}
