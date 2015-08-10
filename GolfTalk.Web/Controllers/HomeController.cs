using GolfTalk.DataAccess;
using GolfTalk.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GolfTalk.Helpers;
using GolfTalk.Models.ViewModels;

namespace GolfTalk.Controllers
{
    public class HomeController : Controller
    {

        private GolfContext db = new GolfContext();

        public ActionResult Index(Guid? teamId = null)
        {
            MainViewModel vm = new MainViewModel();

            List<GolfTalk.Models.Team> teams = db.Teams.ToList();
            List<GolfTalk.Models.Score> scores = db.Scores.ToList();

            List<GolfTalk.Models.TeamsScore> teamScores = (from t in teams
                                                               select new GolfTalk.Models.TeamsScore
                                                               {
                                                                   Name = t.Name,
                                                                   Score = ScoreHelper.CalculateScore(t.TeamID),
                                                                   Thru = ScoreHelper.CalculateThru(t.TeamID),
                                                                   TeamID = t.TeamID,
                                                                   PlayerNames = t.TeamMembers
                                                               }).ToList();

            vm.TeamScores = teamScores.OrderBy(t => t.Score).ToList();
            vm.ChatEntries = db.Chats.OrderByDescending(c => c.ChatID).Take(25).ToList();

            if (teamId.HasValue)
            {
                SetTeamId(teamId);
            }
            else
            {
                teamId = GetTeamId();
            }

            // if team ID still isn't null, show the teams name on the top of the page:
            if (teamId.HasValue)
            {
                Guid teamGuid = Guid.Parse(teamId.ToString());
                GolfTalk.Models.Team thisTeam = db.Teams.Where(t => t.TeamID == teamGuid).FirstOrDefault();
                if (thisTeam != null) vm.TeamName = thisTeam.Name;
            }

            return View(vm);
        }

        private void SetTeamId(Guid? teamId)
        {
            HttpCookie cookie = new HttpCookie("GOLFTALK_TEAM_ID");
            cookie.Value = teamId.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }

        private Guid? GetTeamId()
        {
            if (Request.Cookies["GOLFTALK_TEAM_ID"] != null)
            {
                return new Guid(Request.Cookies["GOLFTALK_TEAM_ID"].Value);
            }

            return null;
        }

        [HttpPost]
        public JsonResult SendTrashTalkMessage(string message)
        {
            HttpCookie cookie = Request.Cookies.Get("GOLFTALK_TEAM_ID");

            if (string.IsNullOrEmpty(message))
            {
                Response.StatusCode = 500;
                return Json("Message Required");
            }
            else if (cookie == null)
            {
                Response.StatusCode = 500;
                return Json("Team ID Required");
            }

            Guid teamId = Guid.Parse(cookie.Value);
            GolfTalk.Models.Team team = db.Teams.Where(t => t.TeamID == teamId).FirstOrDefault();

            message = message + "<i> -" + team.Name + " @ " + DateTime.Now.ToShortTimeString() + "</i>";

            GolfTalk.Models.Chat chatMessage = new GolfTalk.Models.Chat();
            chatMessage.Message = message;
            chatMessage.Team = team;

            db.Chats.Add(chatMessage);
            db.SaveChanges();

            ChatHub.Update(message);

            return Json("Success");
        }


    }
}
