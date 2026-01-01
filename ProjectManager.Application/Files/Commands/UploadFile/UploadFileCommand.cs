using MediatR;
using Microsoft.AspNetCore.Http;


namespace ProjectManager.Application.Files.Commands.UploadFile;
public class UploadFileCommand : IRequest
{
    public IEnumerable<IFormFile> Files { get; set; }
}
