using Microsoft.EntityFrameworkCore;
using Target_Setting_Tool.Web.Contexts;
using Target_Setting_Tool.Web.Models;

namespace Target_Setting_Tool.Web.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _dbcontext;
        public RoleService( ApplicationDbContext rolesDbContext )
        {
            _dbcontext = rolesDbContext;
        }

        public async Task<bool> AddRole( Role role )
        {
            Role roleExists = await FindRoleByName( role.Name );
            if ( roleExists == null )
            {
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                role.CreatedBy = new Guid( "3cee3bc1-7923-4eab-9977-161e258453da" );
                _dbcontext.MST_Roles.AddAsync( role );
                return await _dbcontext.SaveChangesAsync() >= 1 ? true : false;
            }
            else
            {
                return false;
            }

        }

        public async Task DeleteRole( Guid id )
        {
            Role role = await FindRoleById( id );
            role.DeletedDate = DateTime.Now;
            role.IsDeleted = true;
            _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> EditRole( Role role )
        {
            _dbcontext.Entry( role ).State = EntityState.Modified;
            return await _dbcontext.SaveChangesAsync() >= 1 ? true : false;
        }

        public async Task<Role> FindRoleById( Guid id )
        {
            return await _dbcontext.MST_Roles.Where( x => x.Id == id ).FirstOrDefaultAsync();
        }

        public async Task<Role> FindRoleByName( string name )
        {
            return await _dbcontext.MST_Roles.Where( x => x.Name == name ).FirstOrDefaultAsync();
        }

        public async Task<List<Role>> GetAllRoles()
        {
            List<Role> roles = await _dbcontext.MST_Roles.Where( x => x.IsDeleted == false ).ToListAsync();
            return roles;
        }

    }
}
