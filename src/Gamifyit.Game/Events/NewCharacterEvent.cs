namespace Gamifyit.Game.Events
{
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class NewCharacterEvent : Event
    {
        public NewCharacterEvent(Character character)
        {
            this.Character = character;
        }

        public Character Character { get; }
    }
}