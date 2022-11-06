using System.Net;
using System.Net.Http.Headers;
using Costumer.Models;
using Newtonsoft.Json;
using ProjectExamWebClient.Data.Services.AuthProvider;
using ProjectExamWebClient.Interfaces;

namespace ProjectExamWebClient.Data.Services.CustomerServices
{
    public class PersonService : IPersonLoginService
    {
        public HttpClient _httpClient { get; }

        public PersonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Person> GetUserByAccessTokenAsync(string accessToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> LoginAsync(Person person)
        {
            string serializedUser = JsonConvert.SerializeObject(person);

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Person/login");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusConde = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<Person>(responseBody);

            return await Task.FromResult(returnedUser);
        }

        public Task<Person> RefreshTokenAsync(RefreshRequest refreshRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> RegisterUserAsync(Person person)
        {
            string serialzedPerson = JsonConvert.SerializeObject(person);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "person");
            requestMessage.Content = new StringContent(serialzedPerson);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusConde = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            if (responseStatusConde == HttpStatusCode.OK)
            {
                var returnedPerson = JsonConvert.DeserializeObject<Person>(responseBody);

                return await Task.FromResult(returnedPerson);
            }
            else
            {
                return null;
            }
            

        }

        public async Task<IList<Person>> ListAllPersons()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "person");

            var responseMessage = await _httpClient.SendAsync(requestMessage);
            var responeStatusCode = responseMessage.StatusCode;

            if (responeStatusCode.ToString() == "OK")
            {
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<Person>>(responseBody));
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeletePerson(int Id)
        {
            
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"person/{Id}");

            var respone = await _httpClient.SendAsync(requestMessage);
            var responseStatusConde = respone.StatusCode;

            if (responseStatusConde.ToString() == "OK")
            {
                return true;

            }else
            {
                return false;
            }
        }

        public bool UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
