namespace Gamifyit.Politics.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class UnionOfStates : EntityState
    {
        public IList<State> States { get; set; } = new List<State>();

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public UnionOfStates CloneAsSelf()
        {
            var clone = (UnionOfStates)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.States = this.States.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}
