using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactListWebApp.DTOs;
using ContactListWebApp.Mappers;
using ContactListWebApp.Repositories;

namespace ContactListWebApp.Services
{
    public class CompanyService : ICompanyService
    {

        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
        {
            return (await _companyRepository.GetAllCompanies()).Select(CompanyMapper.MapToDto);
        }
    }
}