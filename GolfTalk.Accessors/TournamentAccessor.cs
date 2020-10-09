using GolfTalk.Contracts.Accessor;
using GolfTalk.DataContracts;
using System;
using System.Linq;

namespace GolfTalk.Accessors
{
    public class TournamentAccessor : ITournamentAccessor
    {
        public Tournament Save(TournamentCriteria criteria)
        {
            using (var db = new GolfContext())
            {
                Models.Tournament tourney;

                if (criteria.Id > 0)
                {
                    tourney = db.Tournaments.Single(t => t.Id == criteria.Id);

                    tourney.Name = criteria.Name;
                    tourney.StartDate = ToOffset(criteria.StartDate, criteria.TimeZoneId);
                    tourney.EndDate = ToOffset(criteria.EndDate, criteria.TimeZoneId);
                }
                else
                {
                    tourney = new Models.Tournament()
                    {
                        CreatedAtUtc = DateTime.UtcNow,
                        EndDate = ToOffset(criteria.EndDate, criteria.TimeZoneId),
                        StartDate = ToOffset(criteria.StartDate, criteria.TimeZoneId),
                        Name = criteria.Name
                    };

                    db.Tournaments.Add(tourney);
                }

                db.SaveChanges();

                return new Tournament()
                {
                    CreatedAtUtc = tourney.CreatedAtUtc,
                    EndDate = tourney.EndDate,
                    Id = tourney.Id,
                    Name = tourney.Name,
                    StartDate = tourney.StartDate
                };
            }
        }

        internal static DateTimeOffset ToOffset(DateTime input, string timezoneId)
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);//"Central Standard Time"
            return new DateTimeOffset(input, tz.GetUtcOffset(input));
        }
    }
}
