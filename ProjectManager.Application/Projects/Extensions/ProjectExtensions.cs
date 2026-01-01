using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Projects.Commands.EditDivision;
using ProjectManager.Application.Projects.Commands.EditPosition;
using ProjectManager.Application.Projects.Commands.EditPositionPost;
using ProjectManager.Application.Projects.Commands.EditProject;
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

    public static ProjectBasicsDto ToEditDivision(this Project project)
    {
        if (project == null)
        {
            return null;
        }
        return new ProjectBasicsDto
        {
            Id = project.Id,
            ProjectType = (project.ProjectType).GetDisplayName(),
            Number = project.Number,
            Name = project.Name,
        };
    }

    public static EditProjectCommand ToEditProject(this Project project)
    {
        if (project == null)
        {
            return null;
        }
        return new EditProjectCommand
        {
            Id = project.Id,
            ProjectType = project.ProjectType,
            ProjectStatus = project.Status,
            Number = project.Number,
            Name = project.Name,
            Comment = project.Comment,
            Sharepoint = project.Sharepoint,
            UserPMId = project.UserPMId,
            ClientId = project.ClientId
        };
    }

    public static EditDivisionCommand ToEditDivisionCommand(this Division division)
    {
        if (division == null)
        {
            return null;
        }
        return new EditDivisionCommand
        {
            Id = division.Id,
            UserId = division.UserId,
            DivisionType = (division.DivisionType).GetDisplayName()
        };
    }

    public static EditPositionCommand ToEditPositionCommand(this DivisionPosition position)
    {
        if (position == null)
        {
            return null;
        }
        return new EditPositionCommand
        {
            Id = position.Id,
            DivisionPositionType = position.DivisionPositionType,
            Comment = position.Comment,
            IsCompleted = position.IsCompleted,
            SubContractorId = position.SubContractorId
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
            PositionPosts = position.PositionPosts.OrderByDescending(x=>x.CreatedDate).ToList()
        };
    }

    public static EditPostCommand ToEditPostCommand(this PositionPost post)
    {
        if (post == null)
        {
            return null;
        }
        return new EditPostCommand
        {
            Id = post.Id,
            PositionId = post.PositionId,
            Content = post.Content
        };
    }

}
