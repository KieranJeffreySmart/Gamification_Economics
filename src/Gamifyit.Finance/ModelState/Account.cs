namespace Gamifyit.Finance.ModelState
{
    using System.Collections.Generic;
    using System.Linq;

    using Gamifyit.Framework.DomainObjects;

    public class Account : EntityState
    {
        private int Type { get; set; }

        public string Name { get; set; }

        public List<AccountEntry> Entries { get; set; }

        public override object Clone()
        {
            return this.CloneAsSelf();
        }

        public Account CloneAsSelf()
        {
            var clone = (Account)this.MemberwiseClone();
            clone.Identity = this.Identity.CloneAsSelf();

            clone.Entries = this.Entries.Select(o => o.CloneAsSelf()).ToList();
            return clone;
        }
    }
}