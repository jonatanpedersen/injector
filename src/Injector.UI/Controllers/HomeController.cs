using System;
using System.Web.Mvc;
using Injector.UI.Models;

namespace Injector.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
