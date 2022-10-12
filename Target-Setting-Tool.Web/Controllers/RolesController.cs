using Microsoft.AspNetCore.Mvc;
using Target_Setting_Tool.Web.Models;
using Target_Setting_Tool.Web.Services.RolesServices;

namespace Target_Setting_Tool.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                List<Roles> rolesList = await _rolesService.GetAllRoles();
                return View(rolesList);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> AddRoles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoles(Roles role)
        {
            try
            {
                bool roleExist = await _rolesService.AddRoles(role);
                if (roleExist)
                {
                    TempData["Success"] = "Role Added Successfully!";
                    return RedirectToAction("GetAllRoles");
                }
                else
                {
                    TempData["Error"] = "Role Already Exist!";
                    return View(role);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditRoles(Guid id)
        {
            Roles role = await _rolesService.FindRoleById(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoles(Roles role)
        {
            try
            {
                bool editSuccess = await _rolesService.EditRoles(role);
                if (editSuccess)
                {
                    return RedirectToAction("GetAllRoles");
                }
                else
                {
                    return View(role);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            try
            {
                await _rolesService.DeleteRole(id);
                return RedirectToAction("GetAllRoles");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}
