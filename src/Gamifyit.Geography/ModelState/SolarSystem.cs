namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class SolarSystem : EntityState
    {
        public IList<Planet> Planets { get; set; } = new List<Planet>();
    }
}
