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

        public List<StateIdentity> Assets { get; set; } = new List<StateIdentity>();

        public List<StateIdentity> Accounts { get; set; } = new List<StateIdentity>();

        public decimal NetWorth { get; set; }

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Character CloneAsSelf()
        {
            var clone = (Character)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.Attributes = this.Attributes.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            clone.Assets = this.Assets.Select(id => id.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
