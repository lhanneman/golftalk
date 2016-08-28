using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

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