using AutoMapper;
using ProjectManager.Application.Settlements.Queries.GetFinancialControl;

namespace ProjectManager.Application.Settlements.Mappings;

public class FinancialControlProfile : Profile
{
    public FinancialControlProfile()
    {
        CreateMap<RawFinancialControlScope, InvoiceSumDto>()
            .ForMember(dest => dest.Total,
                opt => opt.Ignore()); // liczone przez FinanceService
    }
}
