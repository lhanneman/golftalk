using System.Collections.Generic;
using System.Web.Mvc;

namespace GolfTalk.Models
{
    public class Hole
    {
        private readonly List<Hole> _holes;

        public Hole()
        {
            
        }

        public Hole(List<Hole> holes)
        {
            _holes = holes;
        }

        public int HoleID { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public int Yards { get; set; }

        public IEnumerable<SelectListItem> HoleList
        {
            get { return new SelectList(_holes, "HoleID", "HoleNumber"); }
        }
    }
}