namespace Gamifyit.Game.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class CharacterType
    {
        private LookupItem name;

        public CharacterType(LookupItem name)
        {
            this.name = name;
        }

        public string Name => this.name.Value;
    }
}