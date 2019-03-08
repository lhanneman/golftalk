﻿using System;

namespace GolfTalk.Accessors.Models
{
    internal class Tournament
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset StartDateUtc { get; set; }

        public DateTimeOffset EndDateUtc { get; set; }

        public DateTimeOffset CreatedAtUtc { get; set; }
    }
}
