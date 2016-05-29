using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactListWebApp.DTOs;
using ContactListWebApp.Mappers;
using ContactListWebApp.Repositories;

namespace ContactListWebApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> AddContact(ContactDto contact)
        {
            try
            {
                return await _contactRepository.AddContact(ContactMapper.MapFromDto(contact));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task DeleteContact(int id)
        {
            try
            {
                await _contactRepository.DeleteContact(id);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

        public Task<int> GetNumberOfFilteredContacts(FilterDto filter)
        {
            return _contactRepository.GetNumberOfFilteredContacts(filter);
        }

        public async Task<IEnumerable<ContactDto>> GetFilteredContacts(FilterDto filter)
        {
            return (await _contactRepository.GetFilteredContacts(filter)).Select(ContactMapper.MapToDto);
        }

        public async Task UpdateContact(ContactDto contact)
        {
            try
            {
                await _contactRepository.UpdateContact(ContactMapper.MapFromDto(contact));
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }
    }
}