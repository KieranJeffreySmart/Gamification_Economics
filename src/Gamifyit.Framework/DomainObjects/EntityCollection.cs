namespace Gamifyit.Framework.DomainObjects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class EntityCollection<TEntity, TState> : IReadOnlyCollection<TEntity>, ICollection<TEntity>
        where TEntity : Entity<TState>
        where TState : EntityState
    {
        public int Count => this.items.Count;
        private IList<TState> states;
        public IEnumerable<TState> States => this.states;
        private List<TEntity> items = new List<TEntity>();
        private readonly Func<TState, TEntity> factory;

        public EntityCollection(IList<TState> states, Func<TState, TEntity> factory)
        {
            this.states = states;
            this.factory = factory;

            this.items.AddRange(this.states.Select(factory));
        }

        public bool IsReadOnly => true;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public void Add(TEntity item)
        {
            this.states.Add(item.State);
            this.items.Add(item);
        }

        public void Clear()
        {
            this.states.Clear();
            this.items.Clear();
        }

        public bool Contains(TEntity item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public bool Remove(TEntity item)
        {
            return this.states.Remove(item.State) ? this.items.Remove(item) : false;
        }
    }


    public class EntityCollectionDictionary<TValueObject, TState> : IReadOnlyDictionary<long, IReadOnlyCollection<TValueObject>> 
        where TValueObject : Entity<TState>
        where TState : EntityState
    {
        private IDictionary<long, IList<TState>> states;

        private readonly Func<IList<TState>, IReadOnlyCollection<TValueObject>> collectionFactory;
        
        private Dictionary<long, IReadOnlyCollection<TValueObject>> items = new Dictionary<long, IReadOnlyCollection<TValueObject>>();

        private Func<TState, TValueObject> valueObjectFactory;

        public EntityCollectionDictionary(IDictionary<long, IList<TState>> states, Func<TState, TValueObject> valueObjectFactory)
        {
            this.valueObjectFactory = valueObjectFactory;
            this.collectionFactory = (state) => new EntityCollection<TValueObject, TState>(state, this.valueObjectFactory);

            this.states = states;
            foreach (var state in this.states)
            {
                var collection = this.collectionFactory(state.Value);
                this.items.Add(state.Key, collection);
            }
        }

        public IEnumerator<KeyValuePair<long, IReadOnlyCollection<TValueObject>>> GetEnumerator()
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

        public bool TryGetValue(long key, out IReadOnlyCollection<TValueObject> value)
        {
            return this.items.TryGetValue(key, out value);
        }

        public IReadOnlyCollection<TValueObject> this[long key] => this.items[key];

        public IEnumerable<long> Keys => this.items.Keys;

        public IEnumerable<IReadOnlyCollection<TValueObject>> Values => this.items.Values;

        public void AddOrUpdate(TValueObject valueObject)
        {
            if (this.items.TryGetValue(valueObject.Identity.Index, out var readonlyCollection))
            {
                if (readonlyCollection is ICollection<TValueObject> collection)
                {
                    collection.Add(valueObject);
                }
            }
            else
            {
                var newStateCollection = new List<TState>();
                this.states.Add(valueObject.Identity.Index, newStateCollection);
                this.items.Add(valueObject.Identity.Index, this.collectionFactory(newStateCollection));
            }
        }
    }
}
