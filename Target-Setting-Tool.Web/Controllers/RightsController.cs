using Microsoft.AspNetCore.Mvc;
using Target_Setting_Tool.Web.Models;
using Target_Setting_Tool.Web.Services.RightsServices;

namespace Target_Setting_Tool.Web.Controllers
{
    public class RightsController : Controller
    {
        readonly IRightsService _rightsService;

        public RightsController(IRightsService rightsService)
        {
            _rightsService = rightsService;
        }
        public async Task<ActionResult> GetAllRights()
        {
            try
            {
                List<Rights> rights = await _rightsService.GetAllRights();
                return View(rights);
            }
            catch (Exception e)
            {
                throw new Exception("" + e);
            }
        }

        [HttpGet]
        public async Task<ActionResult> AddRights(Rights rights)
        {
            return View(rights);
        }


        [HttpPost]
        public async Task<ActionResult> AddRights(int id, Rights rights)
        {
            try
            {
                bool res = await _rightsService.AddRights(rights);
                if (res)
                {
                    return RedirectToAction("GetAllRights");
                }
                else
                {
                    return View(rights);
                }
            }
            catch (Exception e)
            {
                throw new Exception("" + e);
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditRights(Guid id)
        {
            Rights rights = await _rightsService.GetRightsById(id);
            return View(rights);
        }

        [HttpPost]
        public async Task<ActionResult> EditRights(int id, Rights rights)
        {
            try
            {
                bool res = await _rightsService.EditRights(rights);
                if (res)
                {
                    return RedirectToAction("GetAllRights");
                }
                else
                {
                    return View(rights);
                }
            }
            catch (Exception e)
            {
                throw new Exception("" + e);
            }
        }
        public async Task<ActionResult> DeleteRights(Guid id)
        {
            try
            {
                await _rightsService.DeleteRights(id);
                return RedirectToAction("GetAllRights");

            }
            catch (Exception e)
            {
                throw new Exception(e + "");
            }
        }
    }
}
