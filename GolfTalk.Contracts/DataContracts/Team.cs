﻿using System;

namespace GolfTalk.DataContracts
{
    public class Team
    {
        public long Id { get; set; }

        public long TournamentId { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedAtUtc { get; set; }
    }
}