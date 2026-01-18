
using ProjectManager.Application.SubContractors.Commands.EditSubContractor;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.SubContractors.Extension;

public static class ToolExtensions
{
    public static SubContractorBasicsDto ToSubContractorBasicsDto(this SubContractor subContractor)
    {
        if (subContractor == null)
            return null;

        return new SubContractorBasicsDto
        {
            Id = subContractor.Id,
            Email = subContractor.Email,
            Name = subContractor.Name,
            ContactPerson = subContractor.ContactPerson,
        };
    }

    public static EditSubContractorCommand ToEditSubContractorCommand(this SubContractor subContractor)
    {
        if (subContractor == null)
            return null;

        return new EditSubContractorCommand
        {
            Id= subContractor.Id,
            Name = subContractor.Name,
            ContactPerson = subContractor.ContactPerson,
            Email = subContractor.Email,
            PhoneNumber = subContractor.PhoneNumber,
            City = subContractor.Address.City,
            Street = subContractor.Address.Street,
            StreetNumber = subContractor.Address.StreetNumber,
            ZipCode = subContractor.Address.ZipCode
        };
    }
}
