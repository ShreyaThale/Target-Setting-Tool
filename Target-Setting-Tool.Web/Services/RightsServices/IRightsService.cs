using TargetSettingTool.Web.Models;

namespace TargetSettingTool.Web.RightsServices
{
    public interface IRightsService
    {
        Task<List<Rights>> GetAllRights();
        Task<bool> AddRights(Rights rights);
        Task<bool> EditRights(Rights rights);
        Task<Rights> GetRightsById(Guid id);
        Task DeleteRights(Guid id);
    }
}
