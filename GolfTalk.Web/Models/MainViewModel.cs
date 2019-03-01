using System.Collections.Generic;

namespace GolfTalk.Web.Models
{
    public class MainViewModel
    {
        public List<TeamsScore> TeamScores { get; set; }
        public List<Chat> ChatEntries { get; set; }
        public string TeamName { get; set; }

       public ScoreViewModel ScoreData { get; set; }

        public MainViewModel()
        {
            TeamScores = new List<TeamsScore>();
            ChatEntries = new List<Chat>();
            TeamName = string.Empty;
            ScoreData = new ScoreViewModel();
        }
    }
}