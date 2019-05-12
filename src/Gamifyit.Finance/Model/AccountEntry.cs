namespace Gamifyit.Finance.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class AccountEntry : Entity<ModelState.AccountEntry>
    {
        public AccountEntry(ModelState.AccountEntry state)
            : base(state)
        {
            this.CurrencyId = new EntityIdentity(this.State.CurrencyId);
        }

        public EntityIdentity CurrencyId { get; } 

        public decimal GrossAmount => this.State.GrossAmount;
    }
}