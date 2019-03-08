using GolfTalk.Contracts.Manager;
using GolfTalk.Web.Models;
using System.Web.Mvc;

namespace GolfTalk.Controllers
{
    [Authorize]
    public class TournamentsController : Controller
    {
        private readonly ITournamentManager tournamentManager;

        public TournamentsController(ITournamentManager tournamentManager)
        {
            this.tournamentManager = tournamentManager;
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new TournamentViewModel()
            {

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TournamentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var id = tournamentManager.AddTournament(new DataContracts.AddTournamentRequest()
            {
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TimeZone = model.TimeZone,
            });

            return RedirectToAction("detail", "tournaments", new { id });
        }

        [HttpGet]
        public ActionResult Detail (long id)
        {
            var model = new TournamentViewModel()
            {

            };

            return View(model);
        }
    }
}