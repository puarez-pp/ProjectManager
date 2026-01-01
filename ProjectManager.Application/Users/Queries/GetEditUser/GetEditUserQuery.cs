using MediatR;


namespace ProjectManager.Application.Users.Queries.GetEditUser;
public class GetEditUserQuery : IRequest<EditUserVm>
{
    public string UserId { get; set; }
}
