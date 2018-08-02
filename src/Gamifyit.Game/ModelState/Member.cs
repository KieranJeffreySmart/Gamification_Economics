namespace Gamifyit.Game.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class Member : EntityState
    {
        public string Email { get; internal set; }
        public string Username { get; internal set; }
        public IList<StateIdentity> Games { get; set; } = new List<StateIdentity>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Member CloneAsSelf()
        {
            var clone = (Member)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.Games = this.Games.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
