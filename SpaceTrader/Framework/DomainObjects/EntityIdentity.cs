using System;

namespace SpaceTrader.Framework.DomainObjects
{
    public class EntityIdentity
    {
        internal static Func<EntityIdentity, StateIdentity> StateFactory = (vo) => new StateIdentity { Index = vo.Index, Reference = vo.Reference };
        internal static Func<StateIdentity, EntityIdentity> ValueObjectFactory = (s) => new EntityIdentity(s.Index, s.Reference);

        public EntityIdentity(long index, string reference)
        {
            Index = index;
            Reference = reference;
        }

        public long Index { get; }
        public string Reference { get; }
    }
}
