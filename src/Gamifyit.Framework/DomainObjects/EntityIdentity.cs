﻿namespace Gamifyit.Framework.DomainObjects
{
    using System;

    public class EntityIdentity
    {
        public static Func<EntityIdentity, StateIdentity> StateFactory = (vo) => new StateIdentity { Index = vo.Index, Reference = vo.Reference };

        public static Func<StateIdentity, EntityIdentity> ValueObjectFactory = (s) => new EntityIdentity(new StateIdentity(s.Index, s.Reference));

        private StateIdentity state;

        public EntityIdentity(StateIdentity state)
        {
            this.state = state;
        }

        public long Index => this.state.Index;

        public string Reference => this.state.Reference;
        

        public void SetIndex(long index)
        {
            if (this.Index != default(long))
            {
                throw new ArgumentException($"Index is not empty");
            }

            if (index == default(long))
            {
                throw new ArgumentException($"Index can not be empty");
            }

            this.state.Index = index;
        }

        public void SetReference(string reference)
        {
            if (this.Reference != default(string))
            {
                throw new ArgumentException($"Reference is not empty");
            }

            if (string.IsNullOrWhiteSpace(reference))
            {
                throw new ArgumentException($"Reference can not be empty");
            }

            this.state.Reference = reference;
        }
    }
}
