namespace Gamifyit.Chemistry.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Element : EntityState
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rarity { get; set; }

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Element CloneAsSelf()
        {
            var clone = (Element)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}
