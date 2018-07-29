namespace Gamifyit.Game.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Character : EntityState
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public Dictionary<int, int> Attributes { get; set; } = new Dictionary<int, int>();

        public Dictionary<int, StateIdentity> Assets { get; set; } = new Dictionary<int, StateIdentity>();
    }
}
