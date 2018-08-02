namespace Gamifyit.Framework.DomainObjects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class EntityDictionary<TValueObject, TState> : IReadOnlyDictionary<long, TValueObject>
        where TValueObject : Entity<TState>
        where TState : EntityState
    {
        private IDictionary<long, TState> states;

        private readonly Func<TState, TValueObject> collectionFactory;

        private Dictionary<long, TValueObject> items = new Dictionary<long, TValueObject>();

        public EntityDictionary(IDictionary<long, TState> states, Func<TState, TValueObject> valueObjectFactory)
        {
            this.states = states;
            foreach (KeyValuePair<long, TState> state in this.states)
            {
                this.items.Add(state.Key, valueObjectFactory(state.Value));
            }
        }

        public IEnumerator<KeyValuePair<long, TValueObject>> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count => this.items.Count;

        public bool ContainsKey(long key)
        {
            return this.items.ContainsKey(key);
        }

        public bool TryGetValue(long key, out TValueObject value)
        {
            return this.items.TryGetValue(key, out value);
        }

        public TValueObject this[long key] => this.items[key];

        public IEnumerable<long> Keys => this.items.Keys;

        public IEnumerable<TValueObject> Values => this.items.Values;

        public void Add(TValueObject valueObject)
        {
            this.states.Add(valueObject.Identity.Index, valueObject.State);
            this.items.Add(valueObject.Identity.Index, valueObject);
        }
    }
}