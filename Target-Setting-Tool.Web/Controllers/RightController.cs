using Microsoft.AspNetCore.Mvc;
using Target_Setting_Tool.Web.Models;
using Target_Setting_Tool.Web.Services.RightServices;

namespace Target_Setting_Tool.Web.Controllers
{
    public class RightController : Controller
    {
        readonly IRightService _rightsService;

        public RightController( IRightService rightsService )
        {
            _rightsService = rightsService;
        }
        public async Task<ActionResult> GetAllRights()
        {
            try
            {
                List<Right> rights = await _rightsService.GetAllRights();
                return View( rights );
            }
            catch ( Exception e )
            {
                throw new Exception( "" + e );
            }
        }

        [HttpGet]
        public async Task<ActionResult> AddRight( Right rights )
        {
            return View( rights );
        }


        [HttpPost]
        public async Task<ActionResult> AddRight( int id, Right rights )
        {
            try
            {
                bool res = await _rightsService.AddRight( rights );
                if ( res )
                {
                    TempData["Success"] = "Rights Added Succesfully";
                    return RedirectToAction( "GetAllRights" );
                }
                else
                {
                    TempData["Error"] = "Rights Already Exist";
                    return View( rights );
                }
            }
            catch ( Exception e )
            {
                throw new Exception( "" + e );
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditRight( Guid id )
        {
            Right rights = await _rightsService.GetRightById( id );
            return View( rights );
        }

        [HttpPost]
        public async Task<ActionResult> EditRight( int id, Right rights )
        {
            try
            {
                bool res = await _rightsService.EditRight( rights );
                if ( res )
                {
                    TempData["Success"] = "Rights Edited Succesfully";
                    return RedirectToAction( "GetAllRights" );
                }
                else
                {
                    TempData["Error"] = "Rights Already Exist/Unable To Change";
                    return View( rights );
                }
            }
            catch ( Exception e )
            {
                throw new Exception( "" + e );
            }
        }
        public async Task<ActionResult> DeleteRight( Guid id )
        {
            try
            {
                await _rightsService.DeleteRight( id );
                TempData["Success"] = "Rights Deleted Succesfully";
                return RedirectToAction( "GetAllRights" );

            }
            catch ( Exception e )
            {
                throw new Exception( e + "" );
            }
        }
    }
}
