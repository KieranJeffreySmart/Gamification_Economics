namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class NewGameTypeEvent : Event
    {
        public NewGameTypeEvent(EntityIdentity gameTypeId, string gameTypeName)
        {
            this.GameTypeId = gameTypeId;
            this.GameTypeName = gameTypeName;
        }

        public EntityIdentity GameTypeId { get; }

        public string GameTypeName { get; }
    }
}