using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Projects.Queries.GetPosition;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Users.Extensions;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Extensions;

public static class ProjectExtensions
{
    public static ProjectBasicsDto ToBasicsProjectDto(this Project project)
    {
        if (project == null)
        {
            return null;
        }
        return new ProjectBasicsDto
        {
            Id = project.Id,
            ProjectType = (project.ProjectType).GetDisplayName(),
            ProjectStatus = project.Status,
            Number = project.Number,
            Name = project.Name,
            Sharepoint = project.Sharepoint,
            User = (project.User.ToUserDto()).FullName,
            ClientName = project.Client.Name,
            EditDate = project.EditDate,
        };
    }

    public static ProjectDto ToProjectDto(this Project project)
    {
        if (project == null)
        {
            return null;
        }
        return new ProjectDto
        {
            Id = project.Id,
            ProjectType = (project.ProjectType).GetDisplayName(),
            ProjectStatus = project.Status,
            Number = project.Number,
            Name = project.Name,
            Sharepoint = project.Sharepoint,
            Comment = project.Comment,
            User = $"{project.User.FirstName} {project.User.LastName}",
            Client = project.Client.Name,
        };
    }


    public static PositionDto ToPositionDto(this DivisionPosition position)
    {
        if (position == null)
        {
            return null;
        }
        return new PositionDto
        {
            Id = position.Id,
            Name = position.DivisionPositionType,
            Comment = position.Comment,
            IsCompleted = position.IsCompleted,
            PerformedData = position.PerformedData,
            SubContractor = position.SubContractor.Name,
            PositionPosts = position.PositionPosts.Select(x=>x.ToPositionPostDto()).OrderByDescending(x=>x.CreatedDate).ToList()
        };
    }

}
