namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class MembershipCreatedEvent : Event
    {
        private readonly Membership membership;

        public MembershipCreatedEvent(Membership membership)
        {
            this.membership = membership;
        }
    }
}