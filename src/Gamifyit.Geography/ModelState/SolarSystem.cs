namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    public class SolarSystem
    {
        public IList<Planet> Planets { get; set; } = new List<Planet>();
    }
}
