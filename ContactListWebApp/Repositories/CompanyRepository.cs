using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ContactListWebApp.Models;

namespace ContactListWebApp.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            using (var db = new ContactListWebAppContext())
            {
                return await db.Companies.ToListAsync();
            }
        }
    }
}