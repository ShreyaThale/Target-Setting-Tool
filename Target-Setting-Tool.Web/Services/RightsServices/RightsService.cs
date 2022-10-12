using Microsoft.EntityFrameworkCore;
using Target_Setting_Tool.Web.Models;
using Target_Setting_Tool.Web.Contexts;

namespace Target_Setting_Tool.Web.Services.RightsServices
{
    public class RightsService : IRightsService
    {
        private readonly ApplicationDbContext _rightDbContext;
        public RightsService(ApplicationDbContext rightsDbContext)
        {
            _rightDbContext = rightsDbContext;
        }

        public async Task<bool> AddRights(Rights rights)
        {
            bool IsRightExist = await IsRightsExist(rights);
            if (!IsRightExist)
            {
                rights.Id = new Guid();
                rights.CreatedDate = DateTime.Now;
                _rightDbContext.MST_RightsTBl.AddAsync(rights);
                return await _rightDbContext.SaveChangesAsync() >= 1 ? true : false;
            }
            return false;
        }

        private async Task<bool> IsRightsExist(Rights rights)
        {
            Rights res = await _rightDbContext.MST_RightsTBl.Where(x => x.Name == rights.Name && x.IsDeleted == false).FirstOrDefaultAsync();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteRights(Guid id)
        {
            Rights rights = await GetRightsById(id);
            rights.IsDeleted = true;
            _rightDbContext.MST_RightsTBl.Update(rights);
            await _rightDbContext.SaveChangesAsync();

        }

        public async Task<bool> EditRights(Rights rights)
        {
            bool IsRightExist = await IsRightsExist(rights);
            if (!IsRightExist)
            {
                rights.ModifiedDate = DateTime.Now;
                _rightDbContext.MST_RightsTBl.Update(rights);
                return await _rightDbContext.SaveChangesAsync() >= 1 ? true : false;
            }
            return false;
        }

        public async Task<List<Rights>> GetAllRights()
        {
            return await _rightDbContext.MST_RightsTBl.Where(x => x.IsDeleted == false).ToListAsync();

        }

        public async Task<Rights> GetRightsById(Guid id)
        {
            Rights rights = await _rightDbContext.MST_RightsTBl.Where(x => x.Id == id).FirstOrDefaultAsync();
            return rights;
        }
    }
}
