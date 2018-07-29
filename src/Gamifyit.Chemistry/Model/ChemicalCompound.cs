namespace Gamifyit.Chemistry.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class ChemicalCompound : Entity<ModelState.ChemicalCompound>
    {
        public IDictionary<Element, int> Composition { get; set; } = new Dictionary<Element, int>();

        public ChemicalCompound(ModelState.ChemicalCompound state)
            : base(state)
        {
        }
    }
}
