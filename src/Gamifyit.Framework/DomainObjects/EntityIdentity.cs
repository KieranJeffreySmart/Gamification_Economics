namespace Gamifyit.Framework.DomainObjects
{
    using System;

    public class EntityIdentity
    {
        public static Func<EntityIdentity, StateIdentity> StateFactory = (vo) => new StateIdentity { Index = vo.Index, Reference = vo.Reference };
        public static Func<StateIdentity, EntityIdentity> ValueObjectFactory = (s) => new EntityIdentity(s.Index, s.Reference);

        public EntityIdentity(long index, string reference)
        {
            this.Index = index;
            this.Reference = reference;
        }

        public long Index { get; }

        public string Reference { get; }
    }
}
