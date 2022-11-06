using Costumer.Data;
using Customer.Interfaces;
using Customer.Repositorys;

namespace Customer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext _context;
        

        public UnitOfWork(CustomerContext context)
        {
            _context = context;
        }

        public IRoleRepository RoleRepository => new RoleRepository(_context);
        public ICompanyGrouprRepository CompanyGroupRepository => new CompanayGroupRepository(_context);
        public ICompanyCategoryRepository CompanyCategoryRepository => new CompanyCategoryRepository(_context);
        public ICompanyRepository CompanyRepository => new CompanyRepository(_context);
        public IPersonRepository PersonRepository => new PersonRepository(_context);

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }
    }
}
