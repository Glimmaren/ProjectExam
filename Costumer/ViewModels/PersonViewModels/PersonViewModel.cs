using Costumer.Models;
using Customer.Models;
using Customer.ViewModels.CompanyViewModels;

namespace Customer.ViewModels.PersonViewModels
{
    public class PersonViewModel
    {

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Company? Company { get; set; }
        public Role? Role { get; set; }
    }
}
