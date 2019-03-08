using GolfTalk.Web.Models;
using System.Web.Mvc;

namespace GolfTalk.Controllers
{
    [Authorize]
    public class TournamentsController : Controller
    {
        public ActionResult Add()
        {
            var model = new TournamentViewModel()
            {

            };

            return View(model);
        }
    }
}