namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    public class Universe
    {
        public IList<Galaxy> Galaxies { get; set; } = new List<Galaxy>();
    }
}
