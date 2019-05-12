namespace Gamifyit.Finance.Publishers
{
    using System.Threading.Tasks;

    using Gamifyit.Finance.Events;
    using Gamifyit.Finance.Model;
    using Gamifyit.Finance.Repositories;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class CurrencyRepositoryDecorator : ICurrencyRepository
    {
        private readonly ICurrencyRepository innerRepository;

        private readonly IEventMediator eventMediator;

        public CurrencyRepositoryDecorator(ICurrencyRepository innerRepository, IEventMediator eventMediator)
        {
            this.innerRepository = innerRepository;
            this.eventMediator = eventMediator;
        }

        public async Task Add(Currency currency)
        {
            await this.innerRepository.Add(currency);
            await this.eventMediator.Publish(new NewCurrencyEvent(currency.CloneState()));
        }

        public async Task<Currency> Get(EntityIdentity currencyId)
        {
            return await this.innerRepository.Get(currencyId);
        }
    }
}