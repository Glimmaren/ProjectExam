using Costumer.Data;
using Costumer.Models;
using Customer.Interfaces;
using Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repositorys
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CustomerContext _context;

        public CompanyRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCompany(Company company)
        {
            try
            {
                await _context.Companies.AddAsync(company);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCompany(Company company)
        {
            try
            {
                _context.Companies.Remove(company);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Company>> FindCompaniesByName(string name)
        {
            return await _context.Companies
                .Include(c => c.CompanyCategory)
                .Include(c => c.CompanyGroup)
                .Where(c => c.Name.Trim().ToLower().Contains(name.Trim().ToLower()))
                .ToListAsync();
        }

        public async Task<Company> FindCompanyById(int id)
        {
            return await _context.Companies
                .Include(c => c.CompanyCategory)
                .Include(c => c.CompanyGroup)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Company>> ListAllCompanies()
        {
            return await _context.Companies
                .Include(c => c.CompanyCategory)
                .Include(c => c.CompanyGroup)
                .ToListAsync();
        }

        public bool UpdateComapny(Company company)
        {
            try
            {
                _context.Companies.Update(company);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
