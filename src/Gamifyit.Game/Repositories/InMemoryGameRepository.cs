namespace Gamifyit.Game.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public class InMemoryGameRepository : GenericInMemoryEntityRepository<Game, ModelState.Game>, IGameRepository
    {
        protected override Game EntityFactory(ModelState.Game state)
        {
            return new Game(state);
        }

        public async Task Add(IGame game)
        {
            await Task.Run(() =>
                {
                    if (game is Game entity)
                    {
                        this.Add(entity);
                    }
                });
        }

        public async Task<IGame> Get(EntityIdentity identity)
        {
            return await Task.Run(() => this.Get(identity));
        }
    }
}