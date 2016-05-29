namespace ContactListWebApp.DTOs
{
    public class FilterDto
    {
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}