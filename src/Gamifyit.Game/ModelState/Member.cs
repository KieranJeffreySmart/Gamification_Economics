namespace Gamifyit.Game.ModelState
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Member : EntityState
    {
        public string Email { get; internal set; }
        public string Username { get; internal set; }
        public IList<StateIdentity> Games { get; set; } = new List<StateIdentity>();
    }
}
