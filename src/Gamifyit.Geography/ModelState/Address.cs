namespace Gamifyit.Geography.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Address : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Address CloneAsSelf()
        {
            var clone = (Address)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
