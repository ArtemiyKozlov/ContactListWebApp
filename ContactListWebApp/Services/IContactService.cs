using ContactListWebApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactListWebApp.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetFilteredContacts(FilterDto filter);
        Task<int> AddContact(ContactDto contact);
        Task UpdateContact(ContactDto contact);
        Task DeleteContact(int id);
        Task<int> GetNumberOfFilteredContacts(FilterDto filter);
    }
}
