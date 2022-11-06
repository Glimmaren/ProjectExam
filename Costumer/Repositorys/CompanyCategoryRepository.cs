using Costumer.Data;
using Costumer.Models;
using Customer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repositorys
{
    public class CompanyCategoryRepository : ICompanyCategoryRepository
    {
        public readonly CustomerContext _context;

        public CompanyCategoryRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCompanyCategory(CompanyCategory companyCategory)
        {
            try
            {
                await _context.CompanyCategories.AddAsync(companyCategory);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCompanyCategory(CompanyCategory companyCategory)
        {
            try
            {
                _context.CompanyCategories.Remove(companyCategory);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<CompanyCategory>> FindCompanyCategoriesByName(string name)
        {
            return await _context.CompanyCategories.Where(c => c.Name.Trim().ToLower().Contains(name.Trim().ToLower()))
                .ToListAsync();
        }

        public async Task<CompanyCategory> FindCompanyCategoryById(int id)
        {
            return await _context.CompanyCategories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<CompanyCategory>> ListAllCompanyCategory()
        {
            return await _context.CompanyCategories.ToListAsync();
        }

        public bool UpdateCompanyCategory(CompanyCategory companyCategory)
        {
            try
            {
                 _context.CompanyCategories.Update(companyCategory);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
