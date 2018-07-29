namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Galaxy : EntityState
    {
        public IList<SolarSystem> SolarSystems { get; set; } = new List<SolarSystem>();

    }
}
