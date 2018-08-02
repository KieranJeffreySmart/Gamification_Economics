namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class CharacterHasJoinedGameEvent : Event
    {
        public CharacterHasJoinedGameEvent(EntityIdentity character)
        {
            this.Character = character;
        }

        public EntityIdentity Character { get; }
    }


    public class NewPersonalAccountOpenedEvent : Event
    {
        public NewPersonalAccountOpenedEvent(EntityIdentity character)
        {
            this.Character = character;
        }

        public EntityIdentity Character { get; }
    }
}