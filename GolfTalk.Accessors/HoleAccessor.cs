using GolfTalk.Contracts.Accessor;
using GolfTalk.DataContracts;
using System.Linq;

namespace GolfTalk.Accessors
{
    public class HoleAccessor : IHoleAccessor
    {
        public Hole[] ListHoles()
        {
            using (var db = new GolfContext())
            {
                return db.Holes.Select(h => new Hole()
                {
                    HoleNumber = h.HoleNumber,
                    Id = h.Id,
                    Par = h.Par,
                    Yards = h.Yards
                }).ToArray();
            }
        }
    }
}
