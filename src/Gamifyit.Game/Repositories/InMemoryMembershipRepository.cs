namespace Gamifyit.Game.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Game.Model;

    public class InMemoryMembershipRepository : GenericInMemoryEntityRepository<Membership, ModelState.Membership>, IMembershipRepository
    {
        public async Task<Membership> GetByEmailAddress(string email)
        {
            return await Task.Run(() => this.Entities.Values.FirstOrDefault(m => string.Compare(m.Member.EmailAddress.FullAddress, email, StringComparison.InvariantCultureIgnoreCase) == 0));
        }

        public async Task<Membership> GetByUsername(string username)
        {
            return await Task.Run(() => this.Entities.Values.FirstOrDefault(m => string.Compare(m.Member.Username, username, StringComparison.InvariantCultureIgnoreCase) == 0));
        }

        protected override Membership EntityFactory(ModelState.Membership state)
        {
            return new Membership(state);
        }
    }
}
