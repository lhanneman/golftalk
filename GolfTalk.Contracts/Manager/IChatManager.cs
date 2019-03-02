using GolfTalk.DataContracts;

namespace GolfTalk.Contracts.Manager
{
    public interface IChatManager
    {
        Chat[] ListChats();

        void SaveMessage(long teamId, string message);
    }
}
