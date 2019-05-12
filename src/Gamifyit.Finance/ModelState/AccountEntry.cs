namespace Gamifyit.Finance.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class AccountEntry: EntityState
    {
        public StateIdentity CurrencyId { get; set; }

        public decimal GrossAmount { get; set; }

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public AccountEntry CloneAsSelf()
        {
            var clone = (AccountEntry)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();
            return clone;
        }
    }
}