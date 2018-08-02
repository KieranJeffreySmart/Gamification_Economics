namespace Gamifyit.Game.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Membership : EntityState
    {
        public Member Member { get; set; }

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Membership CloneAsSelf()
        {
            var clone = (Membership)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
