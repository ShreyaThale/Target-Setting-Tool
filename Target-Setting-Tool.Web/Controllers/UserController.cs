using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Target_Setting_Tool.Web.Models;
using Target_Setting_Tool.Web.Services.RolesServices;
using Target_Setting_Tool.Web.Services.UserServices;

namespace Target_Setting_Tool.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRolesService _roleService;

        public UserController(IUserService userService, IRolesService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public async Task<IActionResult> Index()
        {
            List<User> users = await _userService.GetAllUser();
            return View(users);
        }

        public async Task<IActionResult> AddUser()
        {
            ViewBag.Roles = new SelectList(await _roleService.GetAllRoles(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            user.Id = new Guid();
            user.CreatedBy = user.Id;
            bool success = await _userService.AddUser(user);
            if (success)
            {
                TempData["type"] = "success";
                TempData["msg"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["type"] = "danger";
                TempData["msg"] = "Email or Employee Code already in use.";
                return View(user); 
            }
        }

        public async Task<IActionResult> EditUser(Guid id)
        {
            ViewBag.Roles = new SelectList(await _roleService.GetAllRoles(), "Id", "Name");
            User user = await _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            user.ModifiedBy = user.Id;
            bool success = await _userService.UpdateUser(user);
            if (success)
            {
                TempData["type"] = "success";
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["type"] = "danger";
                TempData["msg"] = "Email or Employee Code already in use.";
                return View(user);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            bool success = await _userService.DeleteUser(id);
            if (success)
            {
                TempData["type"] = "success";
                TempData["msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["type"] = "danger";
                TempData["msg"] = "Unable to Delete.";
                return RedirectToAction("Index");
            }
        }

        //[HttpPost]
        //public async Task<JsonResult> DeleteUser(Guid id)
        //{
        //    return Json(await _userService.DeleteUser(id));
        //}
    }
}
