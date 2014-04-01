using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /AdminFrontend/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Comments()
        {
            return View();
        }

    }
}
