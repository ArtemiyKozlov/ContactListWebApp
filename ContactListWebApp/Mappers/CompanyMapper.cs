using ContactListWebApp.DTOs;
using ContactListWebApp.Models;

namespace ContactListWebApp.Mappers
{
    public static class CompanyMapper
    {
        public static Company MapFromDto(CompanyDto dtoObject)
        {
            if (dtoObject == null) return null;

            return new Company
            {
                Id = dtoObject.Id,
                CompanyName = dtoObject.CompanyName
            };
        }

        public static CompanyDto MapToDto(Company doObject)
        {
            if (doObject == null) return null;

            return new CompanyDto
            {
                Id = doObject.Id,
                CompanyName = doObject.CompanyName
            };
        }
    }
}