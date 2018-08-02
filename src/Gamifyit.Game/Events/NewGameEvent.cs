using Gamifyit.Game.Model;

namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;

    public class NewGameEvent : Event
    {
        public EntityIdentity Game { get; }

        public NewGameEvent(EntityIdentity game)
        {
            this.Game = game;
        }
    }
}