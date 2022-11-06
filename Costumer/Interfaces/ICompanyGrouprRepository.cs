using Costumer.Models;

namespace Customer.Interfaces
{
    public interface ICompanyGrouprRepository
    {
        Task<bool> AddCompanyGroupAsync(CompanyGroup companyGroup);
        Task<IList<CompanyGroup>> ListAllCompanyGroups();
        Task<CompanyGroup> FindCompanyGroupById(int id);
        Task<IList<CompanyGroup>> FindCompanyGroupsByName(string name);
        bool UpdateCompanyGroup (CompanyGroup companyGroup);
        bool DeleteCompanyGroup(CompanyGroup companyGroup);
    }
}
