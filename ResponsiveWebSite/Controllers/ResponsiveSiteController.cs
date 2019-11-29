using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResponsiveWebSite.Controllers
{
    public class ResponsiveSiteController : Controller
    {
        // GET: ResponsiveSite
        public ActionResult RwdSite()
        {
            return View();
        }
    }
}