using SpaceTrader.Framework;
using SpaceTrader.Framework.DomainObjects;
using System.Collections.Generic;

namespace SpaceTrader.Model
{
    public class Member : Entity<ModelState.Member>
    {
        public Member(ModelState.Member state) : base(state)
        {
            characters = new EntityCollection<Character, ModelState.Character>(this.State.Characters, (s) => new Character(s));
        }

        EntityCollection<Character, ModelState.Character> characters;
        public IReadOnlyCollection<Character> Characters => characters;

        public void AddCharacter(Character character)
        {
            characters.Add(character);
        }
    }
}
