using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTalk.Models.ViewModels
{
    [NotMapped]
    public class MainViewModel
    {
        public List<GolfTalk.Models.TeamsScore> TeamScores { get; set; }
        public List<GolfTalk.Models.Chat> ChatEntries { get; set; }
        public string TeamName { get; set; }

        public MainViewModel()
        {
            TeamScores = new List<TeamsScore>();
            ChatEntries = new List<Chat>();
            TeamName = string.Empty;
        }
    }
}