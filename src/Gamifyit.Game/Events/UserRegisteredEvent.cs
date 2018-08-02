namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class UserRegisteredEvent : Event
    {
        public UserRegisteredEvent(EntityIdentity user)
        {
            this.User = user;
        }

        public EntityIdentity User { get; }
    }
}