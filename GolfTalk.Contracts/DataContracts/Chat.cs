using System;

namespace GolfTalk.DataContracts
{
    public class Chat
    {
        public long Id { get; set; }

        public string SentByUserId { get; set; }

        public long TournamentId { get; set; }

        public string Message { get; set; }

        public DateTimeOffset CreatedAtUtc { get; set; }
    }
}