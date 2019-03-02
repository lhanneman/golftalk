using GolfTalk.DataContracts;

namespace GolfTalk.Contracts.Accessor
{
    public interface ITeamAccessor
    {
        void AddUserToTeam(long teamId, string userId);
        Team[] ListTeams();
        Team Find(FindTeamRequest request);
    }
}
