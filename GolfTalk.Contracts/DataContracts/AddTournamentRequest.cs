using System;

namespace GolfTalk.DataContracts
{
    public class AddTournamentRequest
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TimeZone { get; set; }
    }
}
