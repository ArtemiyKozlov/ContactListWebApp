using ContactListWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListWebApp.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAllJobs();
    }
}
