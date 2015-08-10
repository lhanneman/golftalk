using GolfTalk.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GolfTalk.Helpers
{
    public static class ScoreHelper
    {
        public static int CalculateScore(Guid teamId)
        {
            int score = 0;
            int par = 0;
            GolfContext db = new GolfContext();

            List<GolfTalk.Models.Score> currentScores = db.Scores.Where(s => s.TeamID == teamId).ToList();

            // tally up both the total score for the team, and also the pars for the holes they've completed
            for (int i = 0; i < currentScores.Count(); i++)
            {
                score += currentScores[i].Strokes;
                int holeId = currentScores[i].HoleID;
                GolfTalk.Models.Hole thisHole = db.Holes.Where(h => h.HoleID == holeId).FirstOrDefault();
                if (thisHole != null)
                {
                    par += thisHole.Par;
                }
            }

            return score - par;
        }

        public static int CalculateThru(Guid teamId)
        {
            GolfContext db = new GolfContext();
            List<GolfTalk.Models.Score> scores = db.Scores.Where(s => s.TeamID == teamId).ToList();

            if (scores.Count() > 0)
            {
                GolfTalk.Models.Score lastScore = scores.OrderByDescending(x => x.Hole.HoleNumber).FirstOrDefault();

                if (lastScore != null)
                {
                    return lastScore.Hole.HoleNumber;
                }
            }
            return 0;
        }
    }
}