using Costumer.Models;

namespace Customer.Interfaces
{
    public interface IPersonRepository
    {
        Task<bool> AddPerson(Person person);
        Task<IList<Person>> ListAllPersons();
        Task<Person> FindPersonById(int id);
        Task<IList<Person>> FindPersonsByLastName(string lastName);
        Task<IList<Person>> FindPersonsByFirstName(string firstName);
        bool DeletePerson(Person person);
        bool UpdatePerson(Person person);
        Task<Person> Login(Person person);
    }
}
