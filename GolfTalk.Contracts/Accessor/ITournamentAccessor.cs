using GolfTalk.DataContracts;
using System;

namespace GolfTalk.Contracts.Accessor
{
    public interface ITournamentAccessor
    {
        Tournament Save(TournamentCriteria criteria);
    }

    public class TournamentCriteria
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string TimeZoneId { get; set; }
    }
}
