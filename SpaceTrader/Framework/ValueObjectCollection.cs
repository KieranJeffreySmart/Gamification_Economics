using System;
using System.Collections;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class ValueObjectCollection<TValueObject, TState> : IReadOnlyCollection<TValueObject>, ICollection<TValueObject>
    {
        public int Count => throw new NotImplementedException();
        private ICollection<TState> states;
        public Dictionary<TValueObject, TState> StateMap = new Dictionary<TValueObject, TState>();
        private List<TValueObject> items = new List<TValueObject>();
        private readonly Func<TValueObject, TState> stateFactory;

        public ValueObjectCollection(ICollection<TState> states, Func<TValueObject, TState> stateFactory, Func<TState, TValueObject> valueObjectFactory)
        {
            this.items.AddRange(items);
            this.stateFactory = stateFactory;

            foreach (var state in this.states)
            {
                StateMap.Add(valueObjectFactory(state), state);
            }

            items.AddRange(StateMap.Keys);

            this.states = states;
        }

        public bool IsReadOnly => true;

        public IEnumerator<TValueObject> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public void Add(TValueObject item)
        {
            StateMap.Add(item, this.stateFactory(item));
            states.Add(StateMap[item]);
            items.Add(item);
        }

        public void Clear()
        {
            states.Clear();
            items.Clear();
        }

        public bool Contains(TValueObject item)
        {
            return items.Contains(item);
        }

        public void CopyTo(TValueObject[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(TValueObject item)
        {
            return StateMap.ContainsKey(item) && states.Remove(StateMap[item]) ? items.Remove(item) : false;
        }
    }
}
