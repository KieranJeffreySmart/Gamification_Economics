using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class Universe
    {
        public IList<Galaxy> Galaxies { get; set; } = new List<Galaxy>();
    }
}
