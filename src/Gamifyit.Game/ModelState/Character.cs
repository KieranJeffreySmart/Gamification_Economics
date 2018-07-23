namespace Gamifyit.Game.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Character : EntityState
    {
        public LookupItem Sex { get; set; }
        public LookupItem Type { get; set; }
        public string Name { get; set; }

        public IList<StateIdentity> Companies { get; set; } = new List<StateIdentity>();
        public IList<StateIdentity> Businesses { get; set; } = new List<StateIdentity>();

    }
}
