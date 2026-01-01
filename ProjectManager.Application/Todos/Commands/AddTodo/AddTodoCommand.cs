using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Todos.Commands.AddTodo;

public class AddTodoCommand:IRequest
{
    public int ProjectId { get; set; }

    [Required(ErrorMessage = "Pole 'Tytuł' jest wymagane")]
    [DisplayName("Tytuł")]
    public string Title { get; set; }

    [DisplayName("Termin realizacji")]
    public DateTime? CompletionDate { get; set; }

    [Required(ErrorMessage = "Pole 'Treść' jest wymagane")]
    [DisplayName("Treść")]
    public string Content { get; set; }

    [Required(ErrorMessage = "Pole 'Pracownik' jest wymagane")]
    [DisplayName("Zadanie dla pracownika")]
    public string UserToId { get; set; }
}
