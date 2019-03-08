namespace GolfTalk.DataContracts
{
    public class Hole
    {
        public long Id { get; set; }

        public long CourseId { get; set; }

        public int HoleNumber { get; set; }

        public int Par { get; set; }

        public int Yards { get; set; }

        public int? Handicap { get; set; }
    }
}