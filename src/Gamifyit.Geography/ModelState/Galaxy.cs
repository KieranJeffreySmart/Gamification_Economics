namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    public class Galaxy
    {
        public IList<SolarSystem> SolarSystems { get; set; } = new List<SolarSystem>();

    }
}
