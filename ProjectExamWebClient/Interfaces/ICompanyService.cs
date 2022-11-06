using Customer.Models;

namespace ProjectExamWebClient.Interfaces
{
    public interface ICompanyService
    {
        Task<bool> AddCompany(Company company);
        Task<IList<Company>> ListAllCompanies();
        Task<Company> FindCompanyById(int id);
        Task<IList<Company>> FindCompaniesByName(string name);
        bool DeleteCompany(Company company);
        bool UpdateComapny(Company company);
    }
}
