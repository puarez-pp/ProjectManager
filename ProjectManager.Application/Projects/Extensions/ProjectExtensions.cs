using ProjectManager.Application.Projects.Queries.GetProjectBasics;
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
            ProjectType = project.ProjectType,
            ProjectStatus = project.Status,
            Number = project.Number,
            Name = project.Name,
            Sharepoint = project.Sharepoint,
            EditAt = project.EditAt,
        };
    }
}
