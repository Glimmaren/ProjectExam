using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Customer.Models;

namespace Costumer.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CompanyId { get; set; }
        public int? RoleId { get; set; }
        //[ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}
