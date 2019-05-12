namespace Gamifyit.Finance.ModelState
{
    using Gamifyit.Framework.DomainObjects;
    public class Currency: EntityState
    {
        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public string Name { get; set; }

        public Currency CloneAsSelf()
        {
            var clone = (Currency)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}