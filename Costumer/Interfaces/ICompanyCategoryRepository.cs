using Costumer.Models;

namespace Customer.Interfaces
{
    public interface ICompanyCategoryRepository
    {
        Task<bool> AddCompanyCategory(CompanyCategory companyCategory);
        Task<IList<CompanyCategory>> ListAllCompanyCategory();
        Task<CompanyCategory> FindCompanyCategoryById(int id);
        Task<IList<CompanyCategory>> FindCompanyCategoriesByName(string name);
        bool UpdateCompanyCategory(CompanyCategory companyCategory);
        bool DeleteCompanyCategory(CompanyCategory conCompanyCategory);
    }
}
