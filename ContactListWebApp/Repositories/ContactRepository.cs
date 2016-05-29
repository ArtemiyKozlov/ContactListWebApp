using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ContactListWebApp.DTOs;
using ContactListWebApp.Models;

namespace ContactListWebApp.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public async Task<int> AddContact(Contact contact)
        {
            if (contact == null) throw new ArgumentException("Contact instance is not initiallized");

            using (var db = new ContactListWebAppContext())
            {
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();
                return --contact.Id;
            }
        }


        public async Task DeleteContact(int id)
        {
            using (var db = new ContactListWebAppContext())
            {
                var contactInDb = db.Contacts.FirstOrDefault(x => x.Id == id);

                if (contactInDb == null)
                    throw new InvalidOperationException($"There was no contact with this id: {id}");

                db.Contacts.Remove(contactInDb);
                await db.SaveChangesAsync();
            }
        }

        private IQueryable<Contact> GetFilteredContactsQuery(ContactListWebAppContext db, FilterDto filter)
        {
            return db.Contacts.Where(
                x => (string.IsNullOrEmpty(filter.Gender) || x.Gender.ToUpper() == filter.Gender.ToUpper())
                     &&
                     (string.IsNullOrEmpty(filter.FirstName) ||
                      x.FirstName.ToUpper().Contains(filter.FirstName.ToUpper()))
                     &&
                     (string.IsNullOrEmpty(filter.LastName) ||
                      x.LastName.ToUpper().Contains(filter.LastName.ToUpper())))
                .Include(x => x.Company)
                .Include(x => x.Job);
        }

        public async Task<int> GetNumberOfFilteredContacts(FilterDto filter)
        {
            using (var db = new ContactListWebAppContext())
            {
                Task<int> task;
                if (filter == null)
                {
                    task = new Task<int>(() => db.Contacts.Count());
                }

                task = new Task<int>(() => GetFilteredContactsQuery(db, filter).OrderBy(x => x.Id).Count());
                task.Start();
                return await task;
            }
        }

        public async Task<IEnumerable<Contact>> GetFilteredContacts(FilterDto filter)
        {
            using (var db = new ContactListWebAppContext())
            {
                if (filter == null)
                {
                    return await db.Contacts.ToListAsync();
                }

                return await GetFilteredContactsQuery(db, filter)
                    .OrderBy(x => x.Id)
                    .Skip((filter.PageNumber - 1)*filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();
            }
        }

        public async Task UpdateContact(Contact contact)
        {
            if (contact == null) throw new ArgumentException("Contact instance is not initiallized");


            using (var db = new ContactListWebAppContext())
            {
                var contactInDb = db.Contacts.FirstOrDefault(x => x.Id == contact.Id);

                if (contactInDb == null)
                    throw new InvalidOperationException($"There was no contact with this id: {contact.Id}");

                contactInDb.Avatar = contact.Avatar;
                contactInDb.Company = contact.Company;
                contactInDb.Email = contact.Email;
                contactInDb.FirstName = contact.FirstName;
                contactInDb.Gender = contact.Gender;
                contactInDb.Job = contact.Job;
                contactInDb.LastName = contact.LastName;
                contactInDb.Phone = contact.Phone;
                contactInDb.CompanyId = contact.CompanyId;
                contactInDb.JobId = contact.JobId;

                await db.SaveChangesAsync();
            }
        }
    }
}