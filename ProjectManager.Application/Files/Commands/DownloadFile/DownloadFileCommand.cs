using MediatR;

namespace ProjectManager.Application.Files.Commands.DownloadFile;

public class DownloadFileCommand : IRequest<DownloadFile>
{
    public int Id { get; set; }
}
