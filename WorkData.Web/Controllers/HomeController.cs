using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkData.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : WorkDataBaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}