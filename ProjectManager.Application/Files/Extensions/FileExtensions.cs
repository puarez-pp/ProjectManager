

using ProjectManager.Application.Files.Queries.GetFiles;

namespace ProjectManager.Application.Files.Extensions;
public static class FileExtensions
{
    public static FileDto ToDto(this Domain.Entities.File file)
    {
        if (file == null)
            return null;

        return new FileDto
        {
            Name = file.Name,
            Bytes = file.Bytes,
            Description = file.Description, 
            Id = file.Id,
            Url = $"/Content/Files/{file.Name}"
        };
    }

}
