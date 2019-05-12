namespace Gamifyit.Finance.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    
    using Gamifyit.Framework.DomainObjects;
    public class Account : Entity<ModelState.Account>
    {
        public Account(ModelState.Account state)
            : base(state)
        {
            this.Entries = new EntityCollection<AccountEntry, ModelState.AccountEntry>(state.Entries, this.EntityFactory);
        }

        private AccountEntry EntityFactory(ModelState.AccountEntry state)
        {
            return new AccountEntry(state);
        }

        public string Name => this.State.Name;

        public IReadOnlyCollection<AccountEntry> Entries;
    }
}