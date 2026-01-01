

using ProjectManager.Application.Common.Models;

namespace ProjectManager.Application.Common.Interfaces;
public interface IPdfFileGenerator
{
    Task<byte[]> GetAsync(FileGeneratorParams @params);
}
