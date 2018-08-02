namespace Gamifyit.Game.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class Game : EntityState
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public IList<StateIdentity> Characters { get; set; } = new List<StateIdentity>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Game CloneAsSelf()
        {
            var clone = (Game)this.MemberwiseClone();

            clone.Characters = this.Characters.Select(o => o.CloneAsSelf()).ToList();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}