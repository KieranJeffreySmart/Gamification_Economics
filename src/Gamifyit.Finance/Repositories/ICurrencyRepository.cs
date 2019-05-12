namespace Gamifyit.Finance.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Finance.Model;
    using Gamifyit.Framework.DomainObjects;

    public interface ICurrencyRepository
    {
        Task Add(Currency currency);

        Task<Currency> Get(EntityIdentity currencyId);
    }
}