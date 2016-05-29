using System.Data.Entity;

namespace ContactListWebApp.Models
{
    public class ContactListWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ContactListWebAppContext() : base("name=ContactListWebAppContext")
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Job> Jobs { get; set; }
    }
}
