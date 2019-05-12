namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class PlayerHasJoinedGameEvent : Event
    {
        public PlayerHasJoinedGameEvent(EntityIdentity character, EntityIdentity game)
        {
            this.Character = character;
            this.Game = game;
        }

        public EntityIdentity Character { get; }

        public EntityIdentity Game { get; }
    }
}
