using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Posts.Queries.GetCommnents;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Users.Extensions;
using ProjectManager.Application.Users.Queries.GetUser;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Extensions;


public static class PostExtensions
{

    public static PositionPostDto ToPositionPostDto(this PositionPost post)
    {
        if (post == null)
        {
            return null;
        }
        return new PositionPostDto
        {
            Id = post.Id,
            PositionId = post.PositionId,
            Body = post.Body,
            CreatedAt = post.CreatedAt,
            UserId = post.UserId,
            User = new UserDto
            {
                Id = post.User.Id,
                Email = post.User.Email,
                Phone = post.User.PhoneNumber,
                FirstName = post.User.FirstName,
                LastName = post.User.LastName,
                FullName = post.User.FirstName + " " + post.User.LastName,
                Employee = new EmployeeDto()
            }
        };
    }


    public static PostDto ToPostDto(this Post post)
    {
        if (post == null)
        {
            return null;
        }
        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Body = post.Body,
            CreatedAt = post.CreatedAt,
            User = post.User.ToUserDto().FullName
        };
    }

    public static PostReplyDto ToPostReplyDto(this PostReply post)
    {
        if (post == null)
        {
            return null;
        }
        return new PostReplyDto
        {
            Id = post.Id,
            PostId = post.PostId,
            Content = post.Body,
            CreatedAt = post.CreatedAt,
            User = post.User.ToUserDto().FullName
        };
    }
}



