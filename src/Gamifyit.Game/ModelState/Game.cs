namespace Gamifyit.Game.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Game : EntityState
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public IList<StateIdentity> Characters { get; set; } = new List<StateIdentity>();
    }
}