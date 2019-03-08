using GolfTalk.DataContracts;

namespace GolfTalk.Contracts.Accessor
{
    public interface IChatAccessor
    {
        Chat[] ListChats();

        void SaveMessage(long tournamentId, string message, string sentByUserId);
    }
}
