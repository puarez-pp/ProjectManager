using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Files.Commands.DownloadFile;

public class DownloadFileCommandHandler: IRequestHandler<DownloadFileCommand, DownloadFile>
{
    private readonly IFileManagerService _fileManagerService;
    private readonly IApplicationDbContext _context;

    public DownloadFileCommandHandler(
        IFileManagerService fileManagerService,
        IApplicationDbContext context)
    {
        _fileManagerService = fileManagerService;
        _context = context;
    }
    public async Task<DownloadFile> Handle(DownloadFileCommand request, CancellationToken cancellationToken)
    {
        var file = await _context
            .Files
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (file == null)
            return null;

        var fileData = await _fileManagerService.DownloadAsync(file.Name);
        return new DownloadFile
        {
            FileName = file.Name,
            Bytes = fileData
        };
    }
}
