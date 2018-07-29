namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Planet : EntityState
    {
        public IList<City> Cities { get; set; } = new List<City>();
    }
}
