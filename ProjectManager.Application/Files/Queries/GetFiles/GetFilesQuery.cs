using MediatR;


namespace ProjectManager.Application.Files.Queries.GetFiles;
public class GetFilesQuery : IRequest<IEnumerable<FileDto>>
{

}
