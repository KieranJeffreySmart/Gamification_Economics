namespace Gamifyit.Finance.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class NetWorthIncreased : Event
    {
        public NetWorthIncreased(EntityIdentity characterId, decimal totalNetWorth, decimal netWorthIncrease)
        {
            this.CharacterId = characterId;
            this.TotalNetWorth = totalNetWorth;
            this.NetWorthIncrease = netWorthIncrease;
        }

        public EntityIdentity CharacterId { get; }

        public decimal NetWorthIncrease { get; }

        public decimal TotalNetWorth { get; }
    }
}