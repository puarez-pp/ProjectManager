
using ProjectManager.Application.SubContractors.Commands.EditSubContractor;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.SubContractors.Extension;

public static class SubContractorExtension
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
            City = subContractor.City,
            Street = subContractor.Street,
            StreetNumber = subContractor.StreetNumber,
            ZipCode = subContractor.ZipCode
        };
    }
}
