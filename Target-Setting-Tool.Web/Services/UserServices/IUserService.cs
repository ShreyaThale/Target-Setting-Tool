using Target_Setting_Tool.Web.Models;

namespace Target_Setting_Tool.Web.Services.UserServices
{
    public interface IUserService
    {
        public Task<bool> AddUser(User user);
        public Task<List<User>> GetAllUser();
        public Task<User> GetUserById(Guid id);
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserByEmployeeCode(string employeeCode);
        public Task<bool> UpdateUser(User user);
        public Task<bool> DeleteUser(Guid id);
    }
}
