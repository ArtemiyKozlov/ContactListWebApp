using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ContactListWebApp.DTOs;
using ContactListWebApp.Mappers;
using ContactListWebApp.Repositories;

namespace ContactListWebApp.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<JobDto>> GetAllJobs()
        {
            return (await _jobRepository.GetAllJobs()).Select(JobMapper.MapToDto);
        }
    }
}