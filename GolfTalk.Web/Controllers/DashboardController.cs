using GolfTalk.Web.Models;
using System.Web.Mvc;

namespace GolfTalk.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        
        public ActionResult Index()
        {
            var dashboard = new DashboardViewModel()
            {

            };

            return View(dashboard);
        }
    }
}