using GolfTalk.Contracts.Accessor;
using GolfTalk.DataContracts;
using System;

namespace GolfTalk.Accessors
{
    public class TournamentAccessor : ITournamentAccessor
    {
        public long AddTournament(AddTournamentRequest request)
        {
            using (var db = new GolfContext())
            {
                var model = new Models.Tournament()
                {
                    Name = request.Name,
                    StartDateUtc = ConvertToUtc(request.StartDate, request.TimeZone),
                    EndDateUtc = ConvertToUtc(request.EndDate, request.TimeZone),
                    TimeZone = request.TimeZone
                };

                db.Tournaments.Add(model);
                db.SaveChanges();

                return model.Id;
            }
        }

        internal static DateTime ConvertToUtc(DateTime input, string timezone)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            return TimeZoneInfo.ConvertTimeToUtc(input, timeZoneInfo);
        }
    }
}
