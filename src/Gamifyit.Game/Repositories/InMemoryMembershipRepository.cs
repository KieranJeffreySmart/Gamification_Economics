namespace Gamifyit.Game.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Game.Model;

    public class InMemoryMembershipRepository: IMembershipRepository
    {
        private readonly Dictionary<string, Membership> memberships = new Dictionary<string, Membership>();

        public async Task Add(Membership membership)
        {
            await Task.Run(() => this.memberships.Add(membership.Member.EmailAddress.FullAddress, membership));
        }

        public async Task<Membership> GetByEmailAddress(string email)
        {
            return await Task.Run(() => this.memberships.TryGetValue(email, out var membership) ? membership : null);
        }

        public async Task<Membership> GetByUsername(string username)
        {
            return await Task.Run(() => this.memberships.Values.FirstOrDefault(m => string.Compare(m.Member.Username, username, StringComparison.InvariantCultureIgnoreCase) == 0));
        }
    }
}
