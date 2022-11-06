using Costumer.Data;
using Costumer.Models;
using Customer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customer.Repositorys
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CustomerContext _context;

        public RoleRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRole(Role role)
        {
            try
            {
                _context.Roles.AddAsync(role);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRole(Role role)
        {
            try
            {
                _context.Roles.Remove(role);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Role> FindRoleById(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Role>> FindRolesByName(string name)
        {
            return await _context.Roles.Where(c => 
                c.Name.Trim().ToLower().Contains(name.ToLower().Trim())).ToListAsync();
        }

        public async Task<IList<Role>> ListAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public bool UpdateRole(Role role)
        {
            try
            {
                _context.Roles.Update(role);
                return true;
            }
            catch
            {
                return false;
            } 
        }
    }
}
