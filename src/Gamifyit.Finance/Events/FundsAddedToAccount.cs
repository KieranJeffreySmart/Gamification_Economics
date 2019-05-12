namespace Gamifyit.Finance.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class FundsAddedToAccount : Event
    {
        public FundsAddedToAccount(EntityIdentity accountId)
        {
            this.AccountId = accountId;
        }

        public EntityIdentity AccountId { get; }
    }
}