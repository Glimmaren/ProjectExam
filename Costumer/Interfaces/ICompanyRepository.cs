using Costumer.Models;
using Customer.Models;

namespace Customer.Interfaces
{
    public interface ICompanyRepository
    {
        Task<bool> AddCompany(Company company);
        Task<IList<Company>> ListAllCompanies();
        Task<Company> FindCompanyById(int id);
        Task<IList<Company>> FindCompaniesByName(string name);
        bool DeleteCompany(Company company);
        bool UpdateComapny(Company company);
    }
}
