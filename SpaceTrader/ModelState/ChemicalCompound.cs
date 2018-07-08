using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class ChemicalCompound
    {
        public IDictionary<Element, int> Composition { get; set; } = new Dictionary<Element, int>();
    }
}
