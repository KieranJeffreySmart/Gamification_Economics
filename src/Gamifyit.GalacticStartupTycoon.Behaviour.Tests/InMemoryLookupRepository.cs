namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;

    public class InMemoryLookupRepository : ILookupRepository
    {
        private readonly Dictionary<Type, Dictionary<int, LookupItem>> lookupLists =
            new Dictionary<Type, Dictionary<int, LookupItem>>();

        public Task AddItem(Type type, LookupItem item)
        {
            return Task.Run(
                () =>
                    {
                        if (item.Key == default(int) || type == null)
                        {
                            throw new ArgumentNullException();
                        }

                        if (this.lookupLists.ContainsKey(type))
                        {
                            if (this.lookupLists[type].ContainsKey(item.Key))
                            {
                                throw new ArgumentException($"An item with the same key already exists");
                            }

                            this.lookupLists[type].Add(item.Key, item);
                        }
                        else
                        {
                            this.lookupLists.Add(type, new Dictionary<int, LookupItem>());
                            this.lookupLists[type].Add(item.Key, item);
                        }
                    });
        }

        public Task<LookupItem> Get(Type type, int key)
        {
            return Task.Run(
                () =>
                    {
                        if (!this.lookupLists.TryGetValue(type, out var lookupList))
                        {
                            return default(LookupItem);
                        }

                        if (!lookupList.TryGetValue(key, out var lookupItem))
                        {
                            return default(LookupItem);
                        }

                        return lookupItem;
                    });
        }
    }
}