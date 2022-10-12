using Microsoft.EntityFrameworkCore;
using Target_Setting_Tool.Web.Contexts;
using Target_Setting_Tool.Web.Models;

namespace Target_Setting_Tool.Web.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _userDbContext;
        public UserService( ApplicationDbContext userDbContext )
        {
            _userDbContext = userDbContext;
        }

        public async Task<bool> AddUser( User user )
        {
            User existingUser = await _userDbContext.MST_Users.FirstOrDefaultAsync( u => u.Email == user.Email || u.EmployeeCode == user.EmployeeCode );
            if ( existingUser == null )
            {
                user.CreatedDate = DateTime.Now;
                _userDbContext.MST_Users.AddAsync( user );
                return await _userDbContext.SaveChangesAsync() == 1;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userDbContext.MST_Users.Where( b => b.IsDeleted == false ).Include( u => u.Role ).ToListAsync();
        }

        public async Task<User> GetUserById( Guid id )
        {
            return await _userDbContext.MST_Users.FirstOrDefaultAsync( b => b.IsDeleted == false && b.Id == id );
        }

        public async Task<User> GetUserByEmail( string email )
        {
            return await _userDbContext.MST_Users.FirstOrDefaultAsync( u => u.Email == email );
        }

        public async Task<User> GetUserByEmployeeCode( string employeeCode )
        {
            return await _userDbContext.MST_Users.FirstOrDefaultAsync( u => u.EmployeeCode == employeeCode );
        }

        public async Task<bool> UpdateUser( User user )
        {
            User existingUser = await _userDbContext.MST_Users.FirstOrDefaultAsync( u => (u.Id != user.Id)
                && (u.Email == user.Email || u.EmployeeCode == user.EmployeeCode) );
            if ( existingUser == null )
            {
                user.ModifiedDate = DateTime.Now;
                _userDbContext.Entry<User>( user ).State = EntityState.Modified;
                return await _userDbContext.SaveChangesAsync() == 1;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser( Guid id )
        {
            User user = await _userDbContext.MST_Users.FirstOrDefaultAsync( b => b.IsDeleted == false && b.Id == id );
            user.DeletedDate = DateTime.Now;
            user.DeletedBy = user.Id;
            user.IsDeleted = true;
            _userDbContext.Entry<User>( user ).State = EntityState.Modified;
            return await _userDbContext.SaveChangesAsync() == 1;
        }
    }
}
