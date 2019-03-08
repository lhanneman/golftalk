using System;

namespace GolfTalk.DataContracts
{
    public class Score
    {
        public long Id { get; set; }

        public long TeamId { get; set; }

        public int HoleId { get; set; }

        public int Strokes { get; set; }

        public DateTimeOffset CreatedAtUtc { get; set; }
    }
}