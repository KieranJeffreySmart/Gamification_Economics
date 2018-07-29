using Gamifyit.Game.Model;

namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.Events;

    public class NewGameEvent : Event
    {
        public IGame Game { get; }

        public NewGameEvent(IGame game)
        {
            this.Game = game;
        }
    }
}