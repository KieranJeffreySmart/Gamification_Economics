namespace Gamifyit.Game.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class LookupType
    {
        private readonly List<LookupItem> types = new List<LookupItem>();

        public LookupType(IEnumerable<LookupItem> types)
        {
            this.types.AddRange(types);
        }
    }
}