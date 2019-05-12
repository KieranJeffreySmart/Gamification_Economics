namespace Gamifyit.Game.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Currency : EntityState
    {
        public LookupItem LookupItem { get; set; }

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Currency CloneAsSelf()
        {
            var clone = (Currency)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            clone.LookupItem = this.LookupItem.CloneAsSelf();
            return clone;
        }
    }
}