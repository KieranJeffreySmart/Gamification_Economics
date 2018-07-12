﻿namespace Gamifyit.Game.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class Member : Entity<ModelState.Member>
    {
        public Member(ModelState.Member state) : base(state)
        {
            this.characters = new EntityCollection<Character, ModelState.Character>(this.State.Characters, (s) => new Character(s));
        }

        EntityCollection<Character, ModelState.Character> characters;
        public IReadOnlyCollection<Character> Characters => this.characters;

        public void AddCharacter(Character character)
        {
            this.characters.Add(character);
        }
    }
}