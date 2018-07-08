using SpaceTrader.Framework.DomainObjects;
using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class Character : EntityState
    {
        public IList<StateIdentity> Companies { get; set; } = new List<StateIdentity>();
        public IList<StateIdentity> Businesses { get; set; } = new List<StateIdentity>();
    }
}
