namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class NewMembershipEvent : Event
    {
        public NewMembershipEvent(EntityIdentity membership)
        {
            this.Membership = membership;
        }

        public readonly EntityIdentity Membership;
    }
}