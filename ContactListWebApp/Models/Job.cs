using System.ComponentModel.DataAnnotations;

namespace ContactListWebApp.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
    }
}