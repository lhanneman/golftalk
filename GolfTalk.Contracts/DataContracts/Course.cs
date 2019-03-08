using System;

namespace GolfTalk.DataContracts
{
    public class Course
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedAtUtc { get; set; }
    }
}
