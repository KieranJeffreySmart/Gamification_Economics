namespace Gamifyit.Game.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Patterns;
    using Gamifyit.Game.Model;

    public class InMemoryGameRepository : IGameRepository
    {
        private readonly GenericInMemoryEntityRepository<Game, ModelState.Game> inMemoryEntityRepository;

        public InMemoryGameRepository()
        {
            this.inMemoryEntityRepository = new GenericInMemoryEntityRepository<Game, ModelState.Game>(state => new Game(state));
        }

        public async Task Add(IGame game)
        {
            if (game is Game entity)
            {
                await this.inMemoryEntityRepository.Add(entity);
            }
        }

        public async Task<IGame> Get(EntityIdentity identity)
        {
            return await this.inMemoryEntityRepository.Get(identity);
        }
    }
}