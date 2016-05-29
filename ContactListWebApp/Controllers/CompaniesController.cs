using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ContactListWebApp.Models;
using ContactListWebApp.Services;

namespace ContactListWebApp.Controllers
{
    public class CompaniesController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        // POST: api/Jobs
        [ResponseType(typeof(IEnumerable<Job>))]
        public async Task<IHttpActionResult> GetAllCompanies()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _companyService.GetAllCompanies());
        }
    }
}