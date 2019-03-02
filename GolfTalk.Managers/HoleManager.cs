using GolfTalk.Contracts.Accessor;
using GolfTalk.Contracts.Manager;
using GolfTalk.DataContracts;

namespace GolfTalk.Managers
{
    public class HoleManager : IHoleManager
    {
        private readonly IHoleAccessor holeAccessor;

        public HoleManager(IHoleAccessor holeAccessor)
        {
            this.holeAccessor = holeAccessor;
        }

        public Hole[] ListHoles()
        {
            return holeAccessor.ListHoles();
        }
    }
}
