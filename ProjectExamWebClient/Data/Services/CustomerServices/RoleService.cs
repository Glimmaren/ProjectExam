using Costumer.Models;
using Newtonsoft.Json;
using ProjectExamWebClient.Interfaces;

namespace ProjectExamWebClient.Data.Services.CustomerServices
{
    public class RoleService : IRoleService
    {
        public HttpClient _httpClient { get; }

        public RoleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //httpClient.BaseAddress = new Uri("")
        }

        public Task<bool> AddRole(Role role)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> FindRoleById(int id)
        {
            throw new NotImplementedException();

        }

        public Task<IList<Role>> FindRolesByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Role>> ListAllRoles()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "role");

            var responseMessage = await _httpClient.SendAsync(requestMessage);
            var responeStatusCode = responseMessage.StatusCode;

            if (responeStatusCode.ToString() == "OK")
            {
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<Role>>(responseBody));
            }
            else
            {
                return null;
            }
        }

        public bool UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
