using Costumer.Models;

namespace Customer.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> AddRole(Role role);
        Task<IList<Role>> ListAllRoles();
        Task<Role> FindRoleById(int id);
        Task<IList<Role>> FindRolesByName(string name);
        bool DeleteRole(Role role);
        bool UpdateRole(Role role);
    }
}
