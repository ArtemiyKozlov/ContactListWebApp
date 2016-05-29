using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using ContactListWebApp.Helper;
using ContactListWebApp.Models;

namespace ContactListWebApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ContactListWebAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactListWebAppContext context)
        {
            var contacts = ContactListJsonSerializer.Deserialize(ConfigurationManager
                .AppSettings["PathToJsonFile"]).ToList();

            if (!contacts.Any()) return;

            foreach (var contact in contacts)
            {
                var company = context.Companies.FirstOrDefault(x => x.CompanyName == contact.CompanyName);
                if (company == null)
                {
                    company = new Company {CompanyName = contact.CompanyName};
                    context.Companies.Add(company);
                }

                var job = context.Jobs.FirstOrDefault(x => x.JobTitle == contact.JobTitle);

                if (job == null)
                {
                    job = new Job {JobTitle = contact.JobTitle};
                    context.Jobs.Add(job);
                }

                context.Contacts.Add(
                    new Contact
                    {
                        Gender = contact.Gender,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        Avatar = contact.Avatar,
                        Phone = contact.Phone,
                        Company = company,
                        Job = job
                    });

                context.SaveChanges();
            }
        }
    }
}
