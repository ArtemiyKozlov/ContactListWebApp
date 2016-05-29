using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ContactListWebApp.Models;

namespace ContactListWebApp.Repositories
{
    public class JobRepository : IJobRepository
    {
        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            using (var db = new ContactListWebAppContext())
            {
                return await db.Jobs.ToListAsync();
            }
        }
    }
}