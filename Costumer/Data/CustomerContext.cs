using Costumer.Models;
using Customer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Costumer.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> opt) : base(opt)
        {
            try
            {
                if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator dbCreator)
                {
                    if(!dbCreator.CanConnect()) dbCreator.Create();
                    if(!dbCreator.HasTables()) dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }   
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CompanyGroup> CompanyGroups { get; set; }
        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
