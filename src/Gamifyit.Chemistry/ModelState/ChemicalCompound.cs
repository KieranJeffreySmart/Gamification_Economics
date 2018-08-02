namespace Gamifyit.Chemistry.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class ChemicalCompound : EntityState
    {
        public Dictionary<Element, int> Composition { get; set; } = new Dictionary<Element, int>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public ChemicalCompound CloneAsSelf()
        {
            var clone = (ChemicalCompound)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();


            clone.Composition = this.Composition.ToDictionary(kvp => kvp.Key.CloneAsSelf(), kvp => kvp.Value);
            return clone;
        }
    }
}
