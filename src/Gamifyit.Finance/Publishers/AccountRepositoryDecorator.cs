namespace Gamifyit.Finance.Publishers
{
    using System.Threading.Tasks;

    using Gamifyit.Finance.Model;
    using Gamifyit.Finance.Repositories;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class AccountRepositoryDecorator : IAccountRepository
    {
        private IAccountRepository innerRepository;

        private IEventMediator eventMediator;

        public AccountRepositoryDecorator(IAccountRepository innerRepository, IEventMediator eventMediator)
        {
            this.innerRepository = innerRepository;
            this.eventMediator = eventMediator;
        }

        public async Task<Account> Get(EntityIdentity accountId)
        {
            return await this.innerRepository.Get(accountId);
        }
    }
}