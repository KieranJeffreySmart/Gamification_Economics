namespace Gamifyit.Finance.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class NewPersonalAccountOpenedEvent : Event
    {
        public NewPersonalAccountOpenedEvent(EntityIdentity accountId)
        {
            this.AccountId = accountId;
        }

        public EntityIdentity AccountId { get; }
    }
}