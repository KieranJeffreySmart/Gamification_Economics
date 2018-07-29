namespace Gamifyit.Framework.DomainObjects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ValueObjectCollectionDictionary<TKey, TValueObject, TState> : IReadOnlyDictionary<TKey, IReadOnlyCollection<TValueObject>>
    {
        private IDictionary<TKey, IList<TState>> states;

        private readonly Func<IList<TState>, IReadOnlyCollection<TValueObject>> collectionFactory;

        private readonly Func<TValueObject, TState> stateFactory;

        private Dictionary<TKey, IReadOnlyCollection<TValueObject>> items = new Dictionary<TKey, IReadOnlyCollection<TValueObject>>();

        private Func<TState, TValueObject> valueObjectFactory;

        public ValueObjectCollectionDictionary(IDictionary<TKey, IList<TState>> states, Func<TValueObject, TState> stateFactory, Func<TState, TValueObject> valueObjectFactory)
        {
            this.stateFactory = stateFactory;
            this.valueObjectFactory = valueObjectFactory;
            this.collectionFactory = (state) => new ValueObjectCollection<TValueObject, TState>(state, this.stateFactory, this.valueObjectFactory);

            this.states = states;
            foreach (var state in this.states)
            {
                var collection = this.collectionFactory(state.Value);
                this.items.Add(state.Key, collection);
            }
        }

        public IEnumerator<KeyValuePair<TKey, IReadOnlyCollection<TValueObject>>> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count => this.items.Count;

        public bool ContainsKey(TKey key)
        {
            return this.items.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out IReadOnlyCollection<TValueObject> value)
        {
            return this.items.TryGetValue(key, out value);
        }

        public IReadOnlyCollection<TValueObject> this[TKey key] => this.items[key];

        public IEnumerable<TKey> Keys => this.items.Keys;

        public IEnumerable<IReadOnlyCollection<TValueObject>> Values => this.items.Values;

        public void AddOrUpdate(TKey key, TValueObject valueObject)
        {
            if (this.items.TryGetValue(key, out var readonlyCollection))
            {
                if (readonlyCollection is ICollection<TValueObject> collection)
                {
                    collection.Add(valueObject);
                }
            }
            else
            {
                var newStateCollection = new List<TState>();
                this.states.Add(key, newStateCollection);
                this.items.Add(key, this.collectionFactory(newStateCollection));
            }
        }
    }

    public class ValueObjectDictionary<TKey, TValueObject, TState> : IReadOnlyDictionary<TKey, TValueObject>
    {
        private IDictionary<TKey, TState> states;

        private readonly Func<TValueObject, TState> stateFactory;

        private Dictionary<TKey, TValueObject> items = new Dictionary<TKey, TValueObject>();

        private Func<TState, TValueObject> valueObjectFactory;

        public ValueObjectDictionary(IDictionary<TKey, TState> states, Func<TValueObject, TState> stateFactory, Func<TState, TValueObject> valueObjectFactory)
        {
            this.stateFactory = stateFactory;
            this.valueObjectFactory = valueObjectFactory;

            this.states = states;
            foreach (var state in this.states)
            {
                this.items.Add(state.Key, this.valueObjectFactory(state.Value));
            }
        }
        
        public int Count => this.items.Count;

        public bool ContainsKey(TKey key)
        {
            return this.items.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out TValueObject value)
        {
            return this.items.TryGetValue(key, out value);
        }

        public TValueObject this[TKey key] => this.items[key];

        public IEnumerable<TKey> Keys => this.items.Keys;

        public IEnumerable<TValueObject> Values => this.items.Values;

        public void AddOrUpdate(TKey key, TValueObject valueObject)
        {
            if (this.items.TryGetValue(key, out var readonlyCollection))
            {
                if (readonlyCollection is ICollection<TValueObject> collection)
                {
                    collection.Add(valueObject);
                }
            }
            else
            {
                this.states.Add(key, this.stateFactory(valueObject));
                this.items.Add(key, valueObject);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValueObject>> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }
    }
}