using Costumer.Models;
using Customer.Models;
using Newtonsoft.Json;
using ProjectExamWebClient.Interfaces;

namespace ProjectExamWebClient.Data.Services.CustomerServices
{
    public class CompanyService : ICompanyService
    {
        public HttpClient _httpClient { get; }

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Company>> FindCompaniesByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Company> FindCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Company>> ListAllCompanies()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Company");

            var responseMessage = await _httpClient.SendAsync(requestMessage);
            var responeStatusCode = responseMessage.StatusCode;

            if (responeStatusCode.ToString() == "OK")
            {
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<Company>>(responseBody));
            }
            else
            {
                return null;
            }

        }

        public bool UpdateComapny(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
