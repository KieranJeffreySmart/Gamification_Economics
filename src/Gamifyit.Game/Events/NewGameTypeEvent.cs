namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class NewGameTypeEvent : Event
    {
        public NewGameTypeEvent(GameType gameType)
        {
            this.GameType = gameType;
        }

        public GameType GameType { get; }
    }
}