namespace Gamifyit.Economics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Resource : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Resource CloneAsSelf()
        {
            var clone = (Resource)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
