
using ProjectManager.Application.SubContractors.Commands.EditSubContractor;
using ProjectManager.Application.Tools.Queries.GetRents;
using ProjectManager.Application.Tools.Queries.GetTools;
using ProjectManager.Application.Tools.Queries.GetUserRents;
using ProjectManager.Application.Users.Extensions;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Tools.Extensions;

public static class ToolExtensions
{
    public static ToolDto ToToolDto(this Tool tool)
    {
        if (tool == null)
            return null;

        return new ToolDto
        {
            Id = tool.Id,
            Name = tool.Name,
            SerialNumber = tool.SerialNumber,
            ToolStatus = tool.ToolStatus,
            ValidDate = tool.ValidDate
        };
    }

    public static ToolRentsDto ToToolRentDto(this ToolRent rent)
    {
        if (rent == null)
            return null;

        return new ToolRentsDto
        {
            Id = rent.Id,
            User = rent.User.ToUserDto().FullName,
            RentDate = rent.RentDate,
            ReturnDate = rent.ReturnDate,
        };
    }

    public static UserRentsDto ToUserRentsDto(this ToolRent rent)
    {
        if (rent == null)
            return null;

        return new UserRentsDto
        {
            Id = rent.Id,
            ToolName = rent.Tool.Name,
            RentDate = rent.RentDate,
            ReturnDate = rent.ReturnDate,
        };
    }
}
