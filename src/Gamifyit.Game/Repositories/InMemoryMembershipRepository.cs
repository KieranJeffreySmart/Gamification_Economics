namespace Gamifyit.Game.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Framework.Patterns;
    using Gamifyit.Game.Model;

    public class InMemoryMembershipRepository : IMembershipRepository
    {
        private readonly GenericInMemoryEntityRepository<Membership, ModelState.Membership> inMemoryStore;

        public InMemoryMembershipRepository()
        {
            this.inMemoryStore = new GenericInMemoryEntityRepository<Membership, ModelState.Membership>((state) => new Membership(state));
        }

        public async Task Add(Membership membership)
        {
            await this.inMemoryStore.Add(membership);
        }

        public async Task<Membership> GetByEmailAddress(string email)
        {
            return (await this.inMemoryStore.GetAll()).FirstOrDefault(m => string.Compare(m.Member.EmailAddress.FullAddress, email, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        public async Task<Membership> GetByUsername(string username)
        {
            return (await this.inMemoryStore.GetAll()).FirstOrDefault(m => string.Compare(m.Member.Username, username, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
    }
}
