using AutoMapper;
using ProjectManager.Application.Settlements.Queries.GetInvoices;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Mappings;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDto>()
            .ForMember(dest => dest.ScopeDescription,
                opt => opt.MapFrom(src => src.WorkScope.Description));
    }
}
