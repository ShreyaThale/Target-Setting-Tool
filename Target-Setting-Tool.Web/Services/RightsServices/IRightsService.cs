using Target_Setting_Tool.Web.Models;

namespace Target_Setting_Tool.Web.Services.RightsServices
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
