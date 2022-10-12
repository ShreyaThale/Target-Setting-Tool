using Microsoft.AspNetCore.Mvc;
using Target_Setting_Tool.Web.Models;
using Target_Setting_Tool.Web.Services.RoleServices;

namespace Target_Setting_Tool.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _rolesService;
        public RoleController( IRoleService rolesService )
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                List<Role> rolesList = await _rolesService.GetAllRoles();
                return View( rolesList );
            }
            catch ( Exception e )
            {
                throw new Exception( e.Message );
            }

        }

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole( Role role )
        {
            try
            {
                bool roleExist = await _rolesService.AddRole( role );
                if ( roleExist )
                {
                    TempData["Success"] = "Role Added Successfully!";
                    return RedirectToAction( "GetAllRoles" );
                }
                else
                {
                    TempData["Error"] = "Role Already Exist!";
                    return View( role );
                }
            }
            catch ( Exception e )
            {
                throw new Exception( e.Message );
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditRole( Guid id )
        {
            Role role = await _rolesService.FindRoleById( id );
            return View( role );
        }

        [HttpPost]
        public async Task<IActionResult> EditRole( Role role )
        {
            try
            {
                bool editSuccess = await _rolesService.EditRole( role );
                if ( editSuccess )
                {
                    return RedirectToAction( "GetAllRoles" );
                }
                else
                {
                    return View( role );
                }
            }
            catch ( Exception e )
            {
                throw new Exception( e.Message );
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole( Guid id )
        {
            try
            {
                await _rolesService.DeleteRole( id );
                return RedirectToAction( "GetAllRoles" );
            }
            catch ( Exception e )
            {
                throw new Exception( e.Message );
            }

        }

    }
}
