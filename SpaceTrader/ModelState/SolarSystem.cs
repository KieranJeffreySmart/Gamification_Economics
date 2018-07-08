using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class SolarSystem
    {
        public IList<Planet> Planets { get; set; } = new List<Planet>();
    }
}
