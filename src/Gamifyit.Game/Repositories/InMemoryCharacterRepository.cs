namespace Gamifyit.Game.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Patterns;
    using Gamifyit.Game.Model;

    public class InMemoryCharacterRepository : ICharacterRepository
    {
        private readonly GenericInMemoryEntityRepository<Character, ModelState.Character> inMemoryStore;

        public InMemoryCharacterRepository()
        {
            this.inMemoryStore = new GenericInMemoryEntityRepository<Character, ModelState.Character>((state) => new Character(state));
        }
        
        public async Task Add(Character character)
        {
            await this.inMemoryStore.Add(character);
        }

        public async Task<Character> Get(EntityIdentity identity)
        {
            return await this.inMemoryStore.Get(identity);
        }
    }
}