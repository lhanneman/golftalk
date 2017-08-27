using GolfTalk.DataAccess;
using GolfTalk.SignalR;
using System;
using System.Linq;
using System.Web.Mvc;
using GolfTalk.Helpers;
using GolfTalk.Models.ViewModels;
using GolfTalk.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GolfTalk.Controllers
{
    public class HomeController : Controller
    {

        private GolfContext Context { get; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public HomeController()
        {
            Context = new GolfContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
        }

        public ActionResult Index()
        {
            var vm = new MainViewModel();

            var teams = Context.Teams.ToList();
            var teamScores = (from t in teams
                              select new TeamsScore
                              {
                                  Name = t.Name,
                                  Score = ScoreHelper.CalculateScore(t.TeamID),
                                  Thru = ScoreHelper.CalculateThru(t.TeamID),
                                  TeamID = t.TeamID
                              }).ToList();

            vm.TeamScores = teamScores.OrderBy(t => t.Score).ToList();
            vm.ChatEntries = Context.Chats.OrderByDescending(c => c.ChatID).Take(25).ToList();

            // if team ID still isn't null, show the teams name on the top of the page:
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (!Request.IsAuthenticated || user == null) return View(vm);
            
            vm.TeamName = user.Team.Name;

            // add score data:
            var teamId = user.Team.TeamID;

            // check current hole scores for this team, and default the dropdown to the next hole they'll pick.
            // For example, if the last score they entered was for hole 3, we'll default the dropdown to select hole 4 so they don't have to:
            var last = Context.Scores.Where(s => s.TeamID == teamId).OrderByDescending(h => h.Hole.HoleNumber).FirstOrDefault();

            if (last != null)
            {
                var lastHoleNumber = last.Hole.HoleNumber;
                var nextHole = Context.Holes.FirstOrDefault(h => h.HoleNumber.Equals(lastHoleNumber + 1));
                vm.ScoreData.HoleNumber = nextHole?.HoleNumber ?? 1;
            }

            // we need to tell the page what the par is for this current hole so we can default the "strokes" dropdown to that value:
            var hole = Context.Holes.FirstOrDefault(h => h.HoleNumber.Equals(vm.ScoreData.HoleNumber));

            vm.ScoreData.Strokes = hole?.Par ?? 4; // default strokes this hole to par

            return View(vm);
        }

        [HttpPost]
        [Authorize]
        public JsonResult SendTrashTalkMessage(string message, int timezoneOffset)
        {
            if (string.IsNullOrEmpty(message))
            {
                Response.StatusCode = 500;
                return Json("Message Required");
            }

            var user = UserManager.FindById(User.Identity.GetUserId());
            var team = Context.Teams.FirstOrDefault(t => t.TeamID.Equals(user.Team.TeamID));

            string messageFrom;
            if (team != null)
            {
                messageFrom = !string.IsNullOrEmpty(user.DisplayName) ? user.DisplayName + " (" + team.Name + ")" : team.Name;
            }
            else
            {
                messageFrom = !string.IsNullOrEmpty(user.DisplayName) ? user.DisplayName : user.Email;
            }

            message = message + "<i> -" + messageFrom + " @ " + DateTime.UtcNow.AddMinutes(-1 * timezoneOffset).ToShortTimeString() + "</i>";

            Context.Chats.Add(new Chat
            {
                Message = message,
                Team = team
            });
            Context.SaveChanges();

            ChatHub.Update(message);
            return Json("Success");
        }
    }
}
