using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;  

namespace PMS_MVC.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        WcfGetService.Getservice _OBJService = new WcfGetService.Getservice();
        public ActionResult _IndexMenu()
        {
            try
            {
                List<BusinessEntities.MenuEntities> UserMenu = _OBJService.GetMenuAll().ToList();
                ViewBag.UserMenu = UserMenu;
                return PartialView("_IndexMenu");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
