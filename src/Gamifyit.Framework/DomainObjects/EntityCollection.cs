namespace Gamifyit.Framework.DomainObjects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class EntityCollection<TEntity, TState> : IReadOnlyCollection<TEntity>, ICollection<TEntity>
        where TEntity : Entity<TState>
    {
        public int Count => throw new NotImplementedException();
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
}
