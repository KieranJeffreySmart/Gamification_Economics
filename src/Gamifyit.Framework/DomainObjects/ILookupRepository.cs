namespace Gamifyit.Framework.DomainObjects
{
    using System;
    using System.Threading.Tasks;

    public interface ILookupRepository
    {
        Task AddItem(Type type, LookupItem item);

        Task<LookupItem> Get(Type type, int key);
    }
}