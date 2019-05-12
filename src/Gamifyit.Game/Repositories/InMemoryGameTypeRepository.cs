namespace Gamifyit.Game.Repositories
{
    using System.Threading.Tasks;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Patterns;
    using Gamifyit.Game.Model;

    public class InMemoryGameTypeRepository : IGameTypeRepository
    {
        private readonly GenericInMemoryEntityRepository<GameType, ModelState.GameType> inMemoryEntityRepository;

        public InMemoryGameTypeRepository()
        {
            this.inMemoryEntityRepository = new GenericInMemoryEntityRepository<GameType, ModelState.GameType>(state => new GameType(state));
        }

        public async Task Add(GameType game)
        {
            await this.inMemoryEntityRepository.Add(game);
        }

        public async Task<GameType> Get(EntityIdentity identity)
        {
            return await this.inMemoryEntityRepository.Get(identity);
        }
    }
}