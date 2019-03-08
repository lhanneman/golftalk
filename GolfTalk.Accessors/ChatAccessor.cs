using GolfTalk.Contracts.Accessor;
using GolfTalk.DataContracts;
using System.Linq;

namespace GolfTalk.Accessors
{
    public class ChatAccessor : IChatAccessor
    {
        public Chat[] ListChats()
        {
            using (var db = new GolfContext())
            {
                return db.Chats.Select(c => new Chat()
                {
                    Id = c.Id,
                    Message = c.Message,
                    TournamentId = c.TournamentId,
                    CreatedAtUtc = c.CreatedAtUtc,
                    SentByUserId = c.SentByUserId,
                }).ToArray();
            }
        }

        public void SaveMessage(long tournamentId, string message, string sentByUserId)
        {
            using (var db = new GolfContext())
            {
                var model = new Models.Chat()
                {
                    Message = message,
                    TournamentId = tournamentId,
                    SentByUserId = sentByUserId,
                };

                db.Chats.Add(model);
                db.SaveChanges();
            }
        }
    }
}
