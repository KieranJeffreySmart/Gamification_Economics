namespace Gamifyit.Finance.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Finance.Model;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Patterns;

    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly GenericInMemoryEntityRepository<Account, ModelState.Account> inMemoryRepository;

        public InMemoryAccountRepository()
        {
            this.inMemoryRepository = new GenericInMemoryEntityRepository<Account, ModelState.Account>((state) => new Account(state));
        }

        public async Task<Account> Get(EntityIdentity accountId)
        {
            return await this.inMemoryRepository.Get(accountId);
        }
    }
}