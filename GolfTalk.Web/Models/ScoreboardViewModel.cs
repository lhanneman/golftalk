using System.Collections.Generic;

namespace GolfTalk.Web.Models
{
    public class ScoreboardViewModel
    {
        public List<ScoreboardItem> Scores { get; set; }

        public string TeamName { get; set; }

        public string TotalScore { get; set; }

        public string TeamMembers { get; set; }

        //public ScoreboardViewModel()
        //{
        //    Scores = new List<ScoreboardItem>();
        //    TeamName = string.Empty;
        //    TotalScore = string.Empty;
        //    TeamMembers = string.Empty;
        //}
    }

    public class ScoreboardItem
    {
        public int HoleNumber { get; set; }

        public int Strokes { get; set; }

        public int Par { get; set; }

        public bool CompletedHole { get; set; }

        //public ScoreboardItem()
        //{
        //    HoleNumber = 0;
        //    Strokes = 0;
        //    CompletedHole = false;
        //}
    }
}