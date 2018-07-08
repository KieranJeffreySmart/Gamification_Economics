using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class Galaxy
    {
        public IList<SolarSystem> SolarSystems { get; set; } = new List<SolarSystem>();

    }
}
