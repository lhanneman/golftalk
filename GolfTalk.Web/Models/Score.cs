namespace GolfTalk.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public long TeamID { get; set; }
        public int HoleID { get; set; }
        public int Strokes { get; set; }
        public virtual Team Team { get; set; }
        public virtual Hole Hole { get; set; }
    }
}