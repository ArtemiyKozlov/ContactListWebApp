using ContactListWebApp.DTOs;
using ContactListWebApp.Models;

namespace ContactListWebApp.Mappers
{
    public static class ContactMapper
    {
        public static Contact MapFromDto(ContactDto dtoObject)
        {
            if (dtoObject == null) return null;

            return new Contact
            {
                Id = dtoObject.Id,
                Gender = dtoObject.Gender,
                Phone = dtoObject.Phone,
                Email = dtoObject.Email,
                Avatar = dtoObject.Avatar,
                FirstName = dtoObject.FirstName,
                LastName = dtoObject.LastName,
                CompanyId = dtoObject.Company?.Id ?? 0,
                JobId = dtoObject.Job?.Id ?? 0
            };
        }

        public static ContactDto MapToDto(Contact doObject)
        {
            if (doObject == null) return null;

            return new ContactDto
            {
                Id = doObject.Id,
                Gender = doObject.Gender,
                Phone = doObject.Phone,
                Email = doObject.Email,
                Avatar = doObject.Avatar,
                FirstName = doObject.FirstName,
                LastName = doObject.LastName,
                Company = CompanyMapper.MapToDto(doObject.Company),
                Job = JobMapper.MapToDto(doObject.Job)
            };
        }
    }
}