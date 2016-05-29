using ContactListWebApp.Models;

namespace ContactListWebApp.DTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public CompanyDto Company { get; set; }
        public JobDto Job { get; set; }
    }
}