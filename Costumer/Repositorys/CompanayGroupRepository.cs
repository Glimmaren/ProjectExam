using Costumer.Data;
using Costumer.Models;
using Customer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repositorys
{
    public class CompanayGroupRepository : ICompanyGrouprRepository
    {
        private readonly CustomerContext _context;

        public CompanayGroupRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCompanyGroupAsync(CompanyGroup companyGroup)
        {
            try
            {
                await _context.CompanyGroups.AddAsync(companyGroup);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public  bool DeleteCompanyGroup(CompanyGroup companyGroup)
        {
            try
            {
                 _context.CompanyGroups.Remove(companyGroup);
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CompanyGroup> FindCompanyGroupById(int id)
        {
            return await _context.CompanyGroups.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<CompanyGroup>> FindCompanyGroupsByName(string name)
        {
            return await _context.CompanyGroups.Where(c => c.Name.ToLower().Trim().Contains(name.ToLower().Trim())).ToListAsync();
        }

        public async Task<IList<CompanyGroup>> ListAllCompanyGroups()
        {
            return await _context.CompanyGroups.ToListAsync();
        }

        public bool UpdateCompanyGroup(CompanyGroup companyGroup)
        {
            try
            {
                _context.CompanyGroups.Update(companyGroup);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
