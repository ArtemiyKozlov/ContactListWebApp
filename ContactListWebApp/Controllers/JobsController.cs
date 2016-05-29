using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ContactListWebApp.Models;
using ContactListWebApp.Services;

namespace ContactListWebApp.Controllers
{
    public class JobsController : ApiController
    {
        private IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }


        // POST: api/Jobs
        [ResponseType(typeof (IEnumerable<Job>))]
        public async Task<IHttpActionResult> GetAllJobs()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _jobService.GetAllJobs());
        }
    }
}