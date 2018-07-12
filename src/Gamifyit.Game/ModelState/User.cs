namespace Gamifyit.Game.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class User : EntityState
    {
        public Membership Membership { get; set; }
    }
}
