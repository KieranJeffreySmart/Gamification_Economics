namespace Gamifyit.Framework.DomainObjects
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class ValueObjectCollection<TValueObject, TState> : IReadOnlyCollection<TValueObject>, ICollection<TValueObject>
    {
        public int Count => throw new NotImplementedException();
        private ICollection<TState> states;
        public Dictionary<TValueObject, TState> StateMap = new Dictionary<TValueObject, TState>();
        private List<TValueObject> items = new List<TValueObject>();
        private readonly Func<TValueObject, TState> stateFactory;

        public ValueObjectCollection(ICollection<TState> states, Func<TValueObject, TState> stateFactory, Func<TState, TValueObject> valueObjectFactory)
        {
            this.items.AddRange(this.items);
            this.stateFactory = stateFactory;

            this.states = states;
            foreach (var state in this.states)
            {
                this.StateMap.Add(valueObjectFactory(state), state);
            }

            this.items.AddRange(this.StateMap.Keys);

        }

        public bool IsReadOnly => true;

        public IEnumerator<TValueObject> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public void Add(TValueObject item)
        {
            this.StateMap.Add(item, this.stateFactory(item));
            this.states.Add(this.StateMap[item]);
            this.items.Add(item);
        }

        public void Clear()
        {
            this.states.Clear();
            this.items.Clear();
        }

        public bool Contains(TValueObject item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(TValueObject[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public bool Remove(TValueObject item)
        {
            return this.StateMap.ContainsKey(item) && this.states.Remove(this.StateMap[item]) ? this.items.Remove(item) : false;
        }
    }
}
