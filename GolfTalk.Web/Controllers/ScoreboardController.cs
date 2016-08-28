using System.Linq;
using System.Web.Mvc;
using GolfTalk.DataAccess;
using GolfTalk.Models;
using GolfTalk.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace GolfTalk.Controllers
{
    [Authorize]
    public class ScoreboardController : Controller
    {
        private GolfContext Context { get; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ScoreboardController()
        {
            Context = new GolfContext();
        }

        public ActionResult Index(long teamId)
        {

            var team = Context.Teams.FirstOrDefault(t => t.TeamID.Equals(teamId));
            if (team == null)
            {
                return View(new ScoreboardViewModel());
            }

            var vm = new ScoreboardViewModel
            {
                TeamName = team.Name
            };

            var teamMembers = Context.Users.Where(u => u.TeamID.Equals(teamId)).ToList();

            for (var i = 0; i < teamMembers.Count(); i++)
            {
                var displayName = teamMembers[i].DisplayName;
                var email = teamMembers[i].Email;
                vm.TeamMembers += (!string.IsNullOrEmpty(displayName) ? displayName : email) + ",";
            }

            if (vm.TeamMembers.EndsWith(","))
            {
                vm.TeamMembers = vm.TeamMembers.Remove(vm.TeamMembers.Length - 1);
            }


            var holes = Context.Holes.OrderBy(h => h.HoleNumber).ToList();
            var totalScore = 0;

            foreach (var hole in holes)
            {
                var scoreForHole = Context.Scores.FirstOrDefault(s => s.Hole.HoleNumber.Equals(hole.HoleNumber) && s.TeamID.Equals(teamId));
                var strokes = scoreForHole?.Strokes ?? 0;
                var completedHole = scoreForHole != null;

                vm.Scores.Add(new ScoreboardItem()
                {
                    HoleNumber = hole.HoleNumber,
                    Strokes = strokes,
                    CompletedHole = completedHole,
                    Par = hole.Par
                });
                totalScore += completedHole ? (strokes - hole.Par) : 0;
            }

            if (totalScore == 0)
            {
                vm.TotalScore = totalScore.ToString();
            }
            else if (totalScore > 0)
            {
                vm.TotalScore = "+" + totalScore;
            }
            else
            {
                vm.TotalScore = totalScore.ToString();
            }

            return View(vm);
        }
    }
}