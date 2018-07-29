namespace Gamifyit.Game.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public class InMemoryGameTypeRepository : IGameTypeRepository
    {
        private readonly List<ModelState.GameType> gameTypeStatuses = new List<ModelState.GameType>();
        private readonly EntityCollection<GameType, ModelState.GameType> gameTypes;


        public InMemoryGameTypeRepository()
        {
            this.gameTypes = new EntityCollection<GameType, ModelState.GameType>(this.gameTypeStatuses, this.EntityFactory);
        }

        private GameType EntityFactory(ModelState.GameType state)
        {
            return new GameType(state);
        }

        public async Task Add(GameType gameType)
        {

            await Task.Run(() =>
                {
                    this.gameTypes.Add(gameType);
                });
        }

        public async Task<GameType> Get(EntityIdentity identity)
        {
            return await Task.Run(() =>
                {
                    return this.gameTypes.SingleOrDefault(gt => gt.Identity.Index == identity.Index);
                });
        }
    }
}