using ContactListWebApp.DTOs;
using ContactListWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactListWebApp.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetFilteredContacts(FilterDto filter);
        Task<int> AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(int id);
        Task<int> GetNumberOfFilteredContacts(FilterDto filter);
    }
}
