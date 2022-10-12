using Target_Setting_Tool.Web.Models;


namespace Target_Setting_Tool.Web.Services.RolesServices
{
    public interface IRolesService
    {
        Task<List<Roles>> GetAllRoles();
        Task<Roles> FindRoleByName(string name);
        Task<bool> AddRoles(Roles role);
        Task<bool> EditRoles(Roles role);
        Task DeleteRole(Guid id);
        Task<Roles> FindRoleById(Guid id);
    }
}
