//using GolfTalk.DataAccess;
//using System.Linq;

//namespace GolfTalk.Helpers
//{
//    public static class ScoreHelper
//    {
//        public static int CalculateScore(long teamId)
//        {
//            var score = 0;
//            var par = 0;
//            var db = new GolfContext();

//            var currentScores = db.Scores.Where(s => s.TeamID.Equals(teamId)).ToList();

//            // tally up both the total score for the team, and also the pars for the holes they've completed
//            for (var i = 0; i < currentScores.Count(); i++)
//            {
//                score += currentScores[i].Strokes;
//                var holeId = currentScores[i].HoleID;
//                var thisHole = db.Holes.FirstOrDefault(h => h.HoleID == holeId);
//                if (thisHole != null)
//                {
//                    par += thisHole.Par;
//                }
//            }

//            return score - par;
//        }

//        public static int CalculateThru(long teamId)
//        {
//            var db = new GolfContext();
//            var scores = db.Scores.Where(s => s.TeamID == teamId).ToList();

//            if (!scores.Any()) return 0;

//            var lastScore = scores.OrderByDescending(x => x.Hole.HoleNumber).FirstOrDefault();
//            return lastScore?.Hole.HoleNumber ?? 0;
//        }
//    }
//}