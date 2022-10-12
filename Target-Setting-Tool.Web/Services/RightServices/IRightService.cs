using Target_Setting_Tool.Web.Models;

namespace Target_Setting_Tool.Web.Services.RightServices
{
    public interface IRightService
    {
        Task<List<Right>> GetAllRights();
        Task<bool> AddRight( Right rights );
        Task<bool> EditRight( Right rights );
        Task<Right> GetRightById( Guid id );
        Task DeleteRight( Guid id );
    }
}
