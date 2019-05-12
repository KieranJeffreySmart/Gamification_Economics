namespace Gamifyit.Finance.Repositories
{
    using System.Threading.Tasks;
    using Gamifyit.Finance.Model;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Patterns;

    public class InMemoryCurrencyRepository : ICurrencyRepository
    {
        private readonly GenericInMemoryEntityRepository<Currency, ModelState.Currency> inMemoryStore;

        public InMemoryCurrencyRepository()
        {
            this.inMemoryStore = new GenericInMemoryEntityRepository<Currency, ModelState.Currency>((state) => new Currency(state));
        }

        public async Task Add(Currency currency)
        {
            await this.inMemoryStore.Add(currency);
        }

        public async Task<Currency> Get(EntityIdentity currencyId)
        {
            return await this.inMemoryStore.Get(currencyId);
        }
    }
}