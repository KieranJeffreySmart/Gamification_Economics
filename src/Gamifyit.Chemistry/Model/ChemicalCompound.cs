namespace Gamifyit.Chemistry.Model
{
    using System.Collections.Generic;

    public class ChemicalCompound
    {
        public IDictionary<Element, int> Composition { get; set; } = new Dictionary<Element, int>();
    }
}
