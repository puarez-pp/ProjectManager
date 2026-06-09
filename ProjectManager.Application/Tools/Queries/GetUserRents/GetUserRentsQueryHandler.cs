using AutoMapper;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Tools.Queries.GetUserRents;

public class GetUserRentsQueryHandler : IRequestHandler<GetUserRentsQuery, List<UserRentsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserRentsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<UserRentsDto>> Handle(GetUserRentsQuery request, CancellationToken cancellationToken)
    {
        return await _context
        .Rents
        .AsNoTracking()
        .Where(x => x.UserId == request.UserId)
        .OrderByDescending(x => x.RentDate)
        .ProjectTo<UserRentsDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
    }
}
