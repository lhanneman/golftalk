using GolfTalk.DataContracts;

namespace GolfTalk.Web.Models
{
    public class MainViewModel
    {
        public string TeamName { get; set; }
        public TeamsScore[] TeamScores { get; set; }
        public Chat[] ChatEntries { get; set; }
        public ScoreViewModel ScoreData { get; set; }
    }
}