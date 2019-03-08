using GolfTalk.DataContracts;

namespace GolfTalk.Contracts.Accessor
{
    public interface ITournamentAccessor
    {
        long AddTournament(AddTournamentRequest request);
    }
}
