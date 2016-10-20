using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTestingTutorial.ServiceAgent;

namespace UnitTestingTutorial.Controllers
{
    public class HomeController : Controller
    {
        ICommunityManager _communityManager;
        public HomeController()
        {
            _communityManager = new CommunityManager();
        }

        public HomeController(ICommunityManager communityManager)
        {
            _communityManager = communityManager;
        }
        public ActionResult Index()
        {
            var result = _communityManager.GetCommunities();
            return View(result);
        }

        public ActionResult About()
        {
            Session["Test"] = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}