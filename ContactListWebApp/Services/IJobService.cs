using System.Collections.Generic;
using System.Threading.Tasks;
using ContactListWebApp.DTOs;

namespace ContactListWebApp.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobDto>> GetAllJobs();
    }

}
