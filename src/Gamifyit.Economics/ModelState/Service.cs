namespace Gamifyit.Economics.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Service : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Service CloneAsSelf()
        {
            var clone = (Service)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
