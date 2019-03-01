namespace GolfTalk.DataContracts
{
    public class Score
    {
        public int Id { get; set; }

        public long TeamId { get; set; }

        public int HoleId { get; set; }

        public int Strokes { get; set; }

        public virtual Team Team { get; set; }

        public virtual Hole Hole { get; set; }
    }
}