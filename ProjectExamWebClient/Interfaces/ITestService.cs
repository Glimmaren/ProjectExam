using Costumer.Models;

namespace ProjectExamWebClient.Interfaces
{
    public interface ITestService
    {
        Task<bool> AddRole(Role role);
        Task<IList<Role>> ListAllRoles();
        Task<Role> FindRoleById(int id);
        Task<IList<Role>> FindRolesByName(string name);
        bool DeleteRole(Role role);
        bool UpdateRole(Role role);
    }
}
