using SpaceTrader.Model;

namespace SpaceTrader.Framework.Events
{
    public class Event
    {
    }

    public class MembershipCreatedEvent : Event
    {
        private readonly Membership membership;

        public MembershipCreatedEvent(Membership membership)
        {
            this.membership = membership;
        }
    }

    public class UserRegisteredEvent : Event
    {
        public UserRegisteredEvent(User user)
        {
            this.User = user;
        }

        public User User { get; }
    }
}
