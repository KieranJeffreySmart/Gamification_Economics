namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Universe : EntityState
    {
        public IList<Galaxy> Galaxies { get; set; } = new List<Galaxy>();
    }
}
