using GolfTalk.SignalR;
using System;
using System.Linq;
using System.Web.Mvc;
using GolfTalk.Helpers;
using Microsoft.AspNet.Identity;
using GolfTalk.Web.Models;
using GolfTalk.Contracts.Manager;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace GolfTalk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamManager teamManager;
        private readonly IChatManager chatManager;
        private readonly IHoleManager holeManager;

        private ApplicationUserManager _userManager;

        public HomeController(ITeamManager teamManager, IChatManager chatManager, IHoleManager holeManager)
        {
            this.teamManager = teamManager;
            this.chatManager = chatManager;
            this.holeManager = holeManager;
        }

        public ApplicationUserManager ApplicationUserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            var vm = new MainViewModel
            {
                TeamScores = teamManager.ListTeams().Select(t => new TeamsScore()
                {
                    Name = t.Name,
                    Score = 0,//ScoreHelper.CalculateScore(t.Id),
                    Thru = 0,//ScoreHelper.CalculateThru(t.Id),
                    TeamID = t.Id
                }).OrderBy(t => t.Score).ToArray(),
                ChatEntries = chatManager.ListChats().OrderByDescending(c => c.Id).Take(25).ToArray()
            };

            // if team ID still isn't null, show the teams name on the top of the page:
            if (!Request.IsAuthenticated)
            {
                return View(vm);
            }

            var team = teamManager.Find(new DataContracts.FindTeamRequest()
            {
                UserId = User.Identity.GetUserId()
            });

            vm.TeamName = team.Name;

            // check current hole scores for this team, and default the dropdown to the next hole they'll pick.
            // For example, if the last score they entered was for hole 3, we'll default the dropdown to select hole 4 so they don't have to:
            var last = team.Scores.OrderByDescending(h => h.Hole.HoleNumber).FirstOrDefault();

            var holes = holeManager.ListHoles();

            if (last != null)
            {
                var lastHoleNumber = last.Hole.HoleNumber;
                var nextHole = holes.FirstOrDefault(h => h.HoleNumber.Equals(lastHoleNumber + 1));
                vm.ScoreData.HoleNumber = nextHole?.HoleNumber ?? 1;
            }

            // we need to tell the page what the par is for this current hole so we can default the "strokes" dropdown to that value:
            var hole = holes.FirstOrDefault(h => h.HoleNumber.Equals(vm.ScoreData.HoleNumber));

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

            var user = ApplicationUserManager.FindById(User.Identity.GetUserId());
            // var team = Context.Teams.FirstOrDefault(t => t.TeamID.Equals(user.Team.TeamID));

            var team = teamManager.Find(new DataContracts.FindTeamRequest()
            {
                UserId = User.Identity.GetUserId()
            });

            string messageFrom;
            if (team != null)
            {
                messageFrom = !string.IsNullOrEmpty(user.UserName) ? user.UserName + " (" + team.Name + ")" : team.Name;
            }
            else
            {
                messageFrom = !string.IsNullOrEmpty(user.UserName) ? user.UserName : user.Email;
            }

            message = message + "<i> -" + messageFrom + " @ " + DateTime.UtcNow.AddMinutes(-1 * timezoneOffset).ToShortTimeString() + "</i>";

            //Context.Chats.Add(new Chat
            //{
            //    Message = message,
            //    Team = team
            //});
            //Context.SaveChanges();

            chatManager.SaveMessage(team.Id, message);

            ChatHub.Update(message);
            return Json("Success");
        }
    }
}
