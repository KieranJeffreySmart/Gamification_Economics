namespace Gamifyit.Economics.ModelState
{
    using Gamifyit.Framework.DomainObjects;
    public class Office : EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Office CloneAsSelf()
        {
            var clone = (Office)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
