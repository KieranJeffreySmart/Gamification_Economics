namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class UserRegisteredEvent : Event
    {
        public UserRegisteredEvent(IUser user)
        {
            this.User = user;
        }

        public IUser User { get; }
    }
}