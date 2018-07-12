namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class UserRegisteredEvent : Event
    {
        public UserRegisteredEvent(User user)
        {
            this.User = user;
        }

        public User User { get; }
    }
}