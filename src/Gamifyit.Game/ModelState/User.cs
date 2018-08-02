namespace Gamifyit.Game.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class User : EntityState
    {
        public Membership Membership { get; set; }

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public User CloneAsSelf()
        {
            var clone = (User)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
