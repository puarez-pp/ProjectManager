using ProjectManager.Application.Posts.Queries.GetCommnents;
using ProjectManager.Application.Projects.Queries.GetPosition;
using ProjectManager.Application.Users.Extensions;
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
            Content = post.Content,
            CreatedDate = post.CreatedDate,
            UserId = post.UserId,
            User = post.User.ToUserDto().FullName
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
            Content = post.Content,
            CreatedDate = post.CreatedDate,
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
            Content = post.Content,
            CreatedDate = post.CreatedDate,
            User = post.User.ToUserDto().FullName
        };
    }
}



