using Costumer.Models;
using ProjectExamWebClient.Data.Services.AuthProvider;

namespace ProjectExamWebClient.Interfaces
{
    public interface IPersonLoginService
    {
        public Task<Person> LoginAsync(Person person);
        public Task<Person> RegisterUserAsync(Person user);
        Task<IList<Person>> ListAllPersons();
        public Task<Person> GetUserByAccessTokenAsync(string accessToken);
        public Task<Person> RefreshTokenAsync(RefreshRequest refreshRequest);
        Task<bool> DeletePerson(int id);
        bool UpdatePerson(Person person);
    }
}
