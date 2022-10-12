using Target_Setting_Tool.Web.Models;


namespace Target_Setting_Tool.Web.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> FindRoleByName( string name );
        Task<bool> AddRole( Role role );
        Task<bool> EditRole( Role role );
        Task DeleteRole( Guid id );
        Task<Role> FindRoleById( Guid id );
    }
}
