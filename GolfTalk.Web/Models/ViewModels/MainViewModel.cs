using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTalk.Models.ViewModels
{
    [NotMapped]
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