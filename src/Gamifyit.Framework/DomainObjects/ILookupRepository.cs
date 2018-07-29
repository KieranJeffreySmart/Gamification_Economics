namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;

    public interface ILookupRepository
    {
        Task AddItem(Type type, LookupItem item);

        Task<LookupItem> Get(Type type, int key);
    }
}