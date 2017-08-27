using GolfTalk.DataAccess;
using GolfTalk.Helpers;
using System.Linq;
using System.Web.Mvc;
using GolfTalk.SignalR;
using GolfTalk.Models;
using GolfTalk.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace GolfTalk.Controllers
{
    [Authorize]
    public class ScoresController : Controller
    {
        private GolfContext Context { get; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ScoresController()
        {
            Context = new GolfContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
        }

        // method for adding a score for a team:
        [HttpPost]
        public string Add(ScoreViewModel model)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var teamId = user.Team.TeamID;
            var hole = Context.Holes.FirstOrDefault(h => h.HoleNumber.Equals(model.HoleNumber));
            var holeId = hole.HoleID;
            var nextHole = Context.Holes.FirstOrDefault(h => h.HoleNumber.Equals(hole.HoleNumber + 1));

            // check if they've entered a score for this hole ID already:
            var score = Context.Scores.FirstOrDefault(t => t.TeamID == teamId && t.HoleID.Equals(holeId));

            if (score == null)
            {
                Context.Scores.Add(new Score
                {
                    Strokes = model.Strokes,
                    HoleID = holeId,
                    TeamID = teamId
                });
            }
            else
            {
                score.Strokes = model.Strokes;
            }

            // removing comment for score - per feedback

            //var team = Context.Teams.FirstOrDefault(t => t.TeamID == teamId);
            //var chatMessage = "";

            //if (team != null && hole != null)
            //{
            //    chatMessage = MessageBuilder.GetNewScoreMessage(hole.HoleNumber, team.Name, model.Strokes, hole.Par, model.TimezoneOffset);
            //    Context.Chats.Add(new Chat
            //    {
            //        Message = chatMessage,
            //        TeamID = teamId
            //    });
            //}

            Context.SaveChanges();

            // get this team's score/thru holes for signal R to push out:
            var updatedScore = ScoreHelper.CalculateScore(teamId);
            var thru = ScoreHelper.CalculateThru(teamId);

            // we need to broadcast this new chat message via signal R:
            ChatHub.UpdateScore(teamId.ToString(), updatedScore, thru);
            // ChatHub.Update(chatMessage);

            // return the next hole:
            return nextHole != null ? JsonConvert.SerializeObject(new ScoreViewModel() { HoleNumber = nextHole.HoleNumber, Strokes = nextHole.Par }) : "";
        }
    }
}
