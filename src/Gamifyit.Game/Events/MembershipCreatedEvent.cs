namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class MembershipCreatedEvent : Event
    {
        public MembershipCreatedEvent(Membership membership)
        {
            this.membership = membership;
        }

        private readonly Membership membership;
    }
}