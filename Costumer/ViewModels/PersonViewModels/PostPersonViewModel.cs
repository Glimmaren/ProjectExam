using System.ComponentModel;

namespace Customer.ViewModels.PersonViewModels
{
    public class PostPersonViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CompanyId { get; set; }
        public int? RoleId { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
