namespace Gamifyit.Chemistry.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class ChemicalCompound : EntityState
    {
        public IDictionary<Element, int> Composition { get; set; } = new Dictionary<Element, int>();
    }
}
