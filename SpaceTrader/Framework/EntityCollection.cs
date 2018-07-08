using SpaceTrader.Framework.DomainObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SpaceTrader.Framework
{
    public class EntityCollection<TEntity, TState> : IReadOnlyCollection<TEntity>, ICollection<TEntity>
        where TEntity : Entity<TState>
    {
        public int Count => throw new NotImplementedException();
        private IList<TState> states;
        public IEnumerable<TState> States => states;
        private List<TEntity> items = new List<TEntity>();
        private readonly Func<TState, TEntity> factory;

        public EntityCollection(IList<TState> states, Func<TState, TEntity> factory)
        {
            this.states = states;
            this.factory = factory;

            items.AddRange(this.states.Select(factory));
        }

        public bool IsReadOnly => true;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void Add(TEntity item)
        {
            states.Add(item.State);
            items.Add(item);
        }

        public void Clear()
        {
            states.Clear();
            items.Clear();
        }

        public bool Contains(TEntity item)
        {
            return items.Contains(item);
        }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(TEntity item)
        {
            return states.Remove(item.State) ? items.Remove(item) : false;
        }
    }
}
