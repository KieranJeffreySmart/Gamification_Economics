namespace Gamifyit.Game.ModelState
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class GameType : EntityState
    {
        public LookupItem LookupItem { get; set; }

        public IDictionary<LookupItem, IList<LookupItem>> CharacterAttributes { get; set; } = new Dictionary<LookupItem, IList<LookupItem>>();

        public IDictionary<LookupItem, IList<StateIdentity>> CharacterAssets { get; set; } = new Dictionary<LookupItem, IList<StateIdentity>>();
    }
}