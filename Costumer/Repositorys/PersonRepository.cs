using Costumer.Data;
using Costumer.Models;
using Customer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repositorys
{
    public class PersonRepository : IPersonRepository
    {
        private readonly CustomerContext _context;

        public PersonRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPerson(Person person)
        {
            try
            {
                await _context.Persons.AddAsync(person);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePerson(Person person)
        {
            try
            {
                _context.Persons.Remove(person);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Person>> FindPersonsByLastName(string lastName)
        {
            return await _context.Persons
                .Include(c => c.Company)
                .Include(c => c.Role)
                .Where(c => c.LastName.Trim().ToLower().Contains(lastName.Trim().ToLower())).ToListAsync();
        }

        public async Task<IList<Person>> FindPersonsByFirstName(string firstName)
        {
            return await _context.Persons
                .Include(c => c.Company)
                .Include(c => c.Role)
                .Where(c => c.FirstName.Trim().ToLower().Contains(firstName.Trim().ToLower())).ToListAsync();

        }

        public async Task<Person> FindPersonById(int id)
        {
            return await _context.Persons
                .Include(c => c.Company)
                .Include(c => c.Role)
                .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<IList<Person>> ListAllPersons()
        {
            return await _context.Persons
                .Include(c => c.Company)
                .Include(c => c.Role)
                .ToListAsync();
        }

        public bool UpdatePerson(Person person)
        {
            try
            {
                _context.Persons.Update(person);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Person> Login([FromBody]Person person)
        {
            
               return await _context.Persons
                    .Include(u => u.Role)
                    .Where(u => u.Email == person.Email
                                && u.Password == person.Password).FirstOrDefaultAsync();



            //if (user != null)
            //{
            //    RefreshToken refreshToken = GenerateRefreshToken();
            //    user.RefreshTokens.Add(refreshToken);
            //    await _context.SaveChangesAsync();

            //    userWithToken = new UserWithToken(user);
            //    userWithToken.RefreshToken = refreshToken.Token;
            //}

            //if (person == null)
            //{
            //    return NotFound();
            //}

            //sign your token here here..
            //userWithToken.AccessToken = GenerateAccessToken(user.UserId);
            
       

        }
    }
}
