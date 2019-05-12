namespace Gamifyit.Finance.Events
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class AssetsReceived : Event
    {
        public AssetsReceived(IReadOnlyCollection<EntityIdentity> assetIds, EntityIdentity ownerId, string ownerType)
        {
            this.AssetIds = assetIds;
            this.OwnerId = ownerId;
            this.OwnerType = ownerType;
        }

        public EntityIdentity OwnerId { get; }

        public string OwnerType { get; }

        public IReadOnlyCollection<EntityIdentity> AssetIds { get; }
    }
}