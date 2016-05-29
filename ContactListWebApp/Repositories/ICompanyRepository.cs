using System.Collections.Generic;
using System.Threading.Tasks;
using ContactListWebApp.Models;

namespace ContactListWebApp.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompanies();
    }
}
