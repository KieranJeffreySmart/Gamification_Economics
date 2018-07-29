namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class NewMembershipEvent : Event
    {
        public NewMembershipEvent(Membership membership)
        {
            this.membership = membership;
        }

        private readonly Membership membership;
    }
}