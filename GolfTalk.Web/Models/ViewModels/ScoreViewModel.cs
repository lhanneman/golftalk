using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTalk.Models.ViewModels
{
    [NotMapped]
    public class ScoreViewModel
    {
        public int Strokes { get; set; }
        public int HoleNumber { get; set; }
        public int TimezoneOffset { get; set; }

        public ScoreViewModel()
        {
            Strokes = 0;
            HoleNumber = 1;
        }
    }
}