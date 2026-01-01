using ProjectManager.Application.Users.Commands.EditUser;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Users.Queries.GetEditUser;
public  class EditUserVm
{
    public EditUserCommand User { get; set; }
    public List<UserDto> AvailableManagers { get; set; }
    public string UserFullPathImage { get; set; }
}
