using System;

namespace GolfTalk.DataContracts
{
    public class Tournament
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset StartDateUtc { get; set; }

        public DateTimeOffset EndDateUtc { get; set; }

        public DateTimeOffset CreatedAtUtc { get; set; }

        public string TimeZone { get; set; }
    }
}
