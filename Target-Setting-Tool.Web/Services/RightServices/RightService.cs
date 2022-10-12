using Microsoft.EntityFrameworkCore;
using Target_Setting_Tool.Web.Contexts;
using Target_Setting_Tool.Web.Models;

namespace Target_Setting_Tool.Web.Services.RightServices
{
    public class RightService : IRightService
    {
        private readonly ApplicationDbContext _rightDbContext;
        public RightService( ApplicationDbContext rightsDbContext )
        {
            _rightDbContext = rightsDbContext;
        }

        public async Task<bool> AddRight( Right rights )
        {
            bool IsRightExist = await IsRightsExist( rights );
            if ( !IsRightExist )
            {
                rights.Id = new Guid();
                rights.CreatedDate = DateTime.Now;
                _rightDbContext.MST_Rights.AddAsync( rights );
                return await _rightDbContext.SaveChangesAsync() >= 1 ? true : false;
            }
            return false;
        }

        private async Task<bool> IsRightsExist( Right rights )
        {
            Right res = await _rightDbContext.MST_Rights.Where( x => x.Name == rights.Name && x.IsDeleted == false ).FirstOrDefaultAsync();
            if ( res != null )
            {
                return true;
            }
            return false;
        }

        public async Task DeleteRight( Guid id )
        {
            Right rights = await GetRightById( id );
            rights.IsDeleted = true;
            _rightDbContext.MST_Rights.Update( rights );
            await _rightDbContext.SaveChangesAsync();

        }

        public async Task<bool> EditRight( Right rights )
        {
            bool IsRightExist = await IsRightsExist( rights );
            if ( !IsRightExist )
            {
                rights.ModifiedDate = DateTime.Now;
                _rightDbContext.MST_Rights.Update( rights );
                return await _rightDbContext.SaveChangesAsync() >= 1 ? true : false;
            }
            return false;
        }

        public async Task<List<Right>> GetAllRights()
        {
            return await _rightDbContext.MST_Rights.Where( x => x.IsDeleted == false ).ToListAsync();

        }

        public async Task<Right> GetRightById( Guid id )
        {
            Right rights = await _rightDbContext.MST_Rights.Where( x => x.Id == id ).FirstOrDefaultAsync();
            return rights;
        }
    }
}
