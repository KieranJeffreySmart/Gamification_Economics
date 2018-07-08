using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class City
    {
        public IList<Resource> Resources { get; set; } = new List<Resource>();
    }
}
