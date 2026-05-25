using Microsoft.AspNetCore.Http;

namespace ProjectManager.Application.Common.Interfaces;
public interface IFileManagerService
{
    Task Upload(IEnumerable<IFormFile> files);
    void Delete(string name);
    Task<byte[]> DownloadAsync(string filePath);
}
