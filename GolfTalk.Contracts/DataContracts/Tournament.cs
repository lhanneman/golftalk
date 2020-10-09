using System;

namespace GolfTalk.DataContracts
{
    public class Tournament
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public DateTime CreatedAtUtc { get; set; }
    }
}
