using System.ComponentModel.DataAnnotations;

namespace ContactListWebApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public int JobId { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }

        public virtual Company Company { get; set; }
        public virtual Job Job { get; set; }
    }
}