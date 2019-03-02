using GolfTalk.DataContracts;

namespace GolfTalk.Contracts.Accessor
{
    public interface IChatAccessor
    {
        Chat[] ListChats();

        void SaveMessage(long teamId, string message);
    }
}
