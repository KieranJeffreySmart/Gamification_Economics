namespace Gamifyit.Game.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class Character : EntityState
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public Dictionary<int, int> Attributes { get; set; } = new Dictionary<int, int>();

        public Dictionary<int, StateIdentity> Assets { get; set; } = new Dictionary<int, StateIdentity>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Character CloneAsSelf()
        {
            var clone = (Character)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.Attributes = this.Attributes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            clone.Assets = this.Assets.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.CloneAsSelf());
            return clone;
        }
    }
}
