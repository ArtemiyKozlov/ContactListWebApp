using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactListWebApp.DTOs;

namespace ContactListWebApp.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies();
    }
}
