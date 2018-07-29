namespace Gamifyit.Game.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public class InMemoryCharacterRepository : ICharacterRepository
    {
        private readonly Dictionary<long, Character> characters = new Dictionary<long, Character>();

        public async Task Add(Character character)
        {
            await Task.Run(() => this.characters.Add(character.Identity.Index, character));
        }

        public async Task<Character> Get(EntityIdentity identity)
        {
            return await Task.Run(() => this.characters.TryGetValue(identity.Index, out var game) ? game : null);
        }
    }
}