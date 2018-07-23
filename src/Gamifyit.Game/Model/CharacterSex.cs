namespace Gamifyit.Game.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class CharacterSex
    {
        private readonly LookupItem classification;

        public CharacterSex(LookupItem classification)
        {
            this.classification = classification;
        }

        public string Classification => this.classification.Value;
    }
}