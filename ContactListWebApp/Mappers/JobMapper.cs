using ContactListWebApp.DTOs;
using ContactListWebApp.Models;

namespace ContactListWebApp.Mappers
{
    public static class JobMapper
    {
        public static Job MapFromDto(JobDto dtoObject)
        {
            if (dtoObject == null) return null;

            return new Job
            {
                Id = dtoObject.Id,
                JobTitle = dtoObject.JobTitle
            };
        }

        public static JobDto MapToDto(Job doObject)
        {
            if (doObject == null) return null;

            return new JobDto
            {
                Id = doObject.Id,
                JobTitle = doObject.JobTitle
            };
        }
    }
}