namespace Gamifyit.Game.ModelState
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class GameType : EntityState
    {
        public LookupItem LookupItem { get; set; }

        public Dictionary<LookupItem, List<LookupItem>> CharacterAttributes { get; set; } = new Dictionary<LookupItem, List<LookupItem>>();

        public Dictionary<LookupItem, List<StateIdentity>> CharacterAssets { get; set; } = new Dictionary<LookupItem, List<StateIdentity>>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public GameType CloneAsSelf()
        {
            var clone = (GameType)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.LookupItem = this.LookupItem.CloneAsSelf();

            clone.CharacterAttributes = this.CharacterAttributes.ToDictionary(
                kvp => kvp.Key.CloneAsSelf(),
                kvp => kvp.Value.Select(v => v.CloneAsSelf()).ToList());

            clone.CharacterAssets = this.CharacterAssets.ToDictionary(
                kvp => kvp.Key.CloneAsSelf(),
                kvp => kvp.Value.Select(v => v.CloneAsSelf()).ToList());

            return clone;
        }
    }
}