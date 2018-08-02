namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class NewCharacterEvent : Event
    {
        public NewCharacterEvent(EntityIdentity character)
        {
            this.Character = character;
        }

        public EntityIdentity Character { get; }
    }
}