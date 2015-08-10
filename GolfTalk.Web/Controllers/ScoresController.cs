using GolfTalk.DataAccess;
using GolfTalk.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GolfTalk.SignalR;

namespace GolfTalk.Controllers
{
    public class ScoresController : Controller
    {

        private GolfContext db = new GolfContext();

        // get the view for adding a score:
        [HttpGet]
        public ActionResult Add(Guid? teamId = null)
        {
            // if a team ID was not provided, check for a cookie:
            if (teamId == null)
            {
                // get team ID from cookie:
                teamId = GetTeamId();

                if (teamId == null)
                {
                    // still null?
                    return RedirectToAction("Index", "Error", new { message = "Team ID not found. Please refer to the email you received with the link which contains your team ID and navigate back to the site from there." });
                }
            }
            else if (teamId.HasValue)
            {
                // put this in the cookie:
                SetTeamId(teamId);
            }

            // check current hole scores for this team, and default the dropdown to the next hole they'll pick.
            // For example, if the last score they entered was for hole 3, we'll default the dropdown to select hole 4 so they don't have to:
            GolfTalk.Models.Score last = db.Scores.Where(s => s.TeamID == teamId).OrderByDescending(h => h.Hole.HoleNumber).FirstOrDefault();
            int thisHole = last != null ? last.Hole.HoleNumber + 1 : 1;
            ViewBag.HoleList = new SelectList(db.Holes.OrderBy(h => h.HoleNumber), "HoleID", "HoleNumber", thisHole);

            // we need to tell the page what the par is for this current hole so we can default the "strokes" dropdown to that value:
            GolfTalk.Models.Hole hole = db.Holes.Where(h => h.HoleNumber == thisHole).FirstOrDefault();
            int thisPar = hole != null ? hole.Par : 4;
            ViewBag.StrokeList = new SelectList(Enumerable.Range(1, 20), thisPar);

            ViewBag.TeamID = teamId;

            return View("InputScore");
        }

        // method for adding a score for a team:
        [HttpPost]
        public ActionResult Add(Guid? teamId, int holeID, int strokes)
        {

            // if a team ID was not provided, check for a cookie:
            if (teamId == null)
            {
                // get team ID from cookie:
                teamId = GetTeamId();

                if (teamId == null)
                {
                    // still null?
                    return RedirectToAction("Index", "Error", new { message = "Team ID not found. Please refer to the email you received with the link which contains your team ID and navigate back to the site from there." });
                }
            }

            // check if they've entered a score for this hole ID already:
            GolfTalk.Models.Score score = db.Scores.Where(t => t.TeamID == teamId && t.HoleID == holeID).FirstOrDefault();

            if (score == null)
            {
                score = new Models.Score();
                score.Strokes = strokes;
                score.HoleID = holeID;
                score.TeamID = new Guid(teamId.ToString());
                db.Scores.Add(score);
            } else
            {
                score.Strokes = strokes;
            }


            GolfTalk.Models.Chat newChat = new Models.Chat();

            GolfTalk.Models.Team team = db.Teams.Where(t => t.TeamID == teamId).FirstOrDefault();
            GolfTalk.Models.Hole hole = db.Holes.Where(h => h.HoleID == holeID).FirstOrDefault();
            newChat.Message = MessageBuilder.GetNewScoreMessage(hole.HoleNumber, team.Name, strokes, hole.Par);
            newChat.TeamID = Guid.Parse(teamId.ToString());

            db.Chats.Add(newChat);
            
            db.SaveChanges();

            // get this team's score/thru holes for signal R to push out:
            int updatedScore = ScoreHelper.CalculateScore(Guid.Parse(teamId.ToString()));
            int thru = ScoreHelper.CalculateThru(Guid.Parse(teamId.ToString()));

            // we need to broadcast this new chat message via signal R:
            ChatHub.UpdateScore(teamId.ToString(), updatedScore, thru);
            ChatHub.Update(newChat.Message);

            return RedirectToAction("Index", "Home", new { teamId = teamId.ToString() });
        }

        private Guid? GetTeamId()
        {
            if (Request.Cookies["GOLFTALK_TEAM_ID"] != null)
            {
                return new Guid(Request.Cookies["GOLFTALK_TEAM_ID"].Value);
            }

            return null;
        }

        private void SetTeamId(Guid? teamId)
        {
            HttpCookie cookie = new HttpCookie("GOLFTALK_TEAM_ID");
            cookie.Value = teamId.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }

    }
}
