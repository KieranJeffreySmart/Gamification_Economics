namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class NewGameTypeEvent : Event
    {
        public NewGameTypeEvent(EntityIdentity gameType)
        {
            this.GameType = gameType;
        }

        public EntityIdentity GameType { get; }
    }
}