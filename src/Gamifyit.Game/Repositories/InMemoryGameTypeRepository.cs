namespace Gamifyit.Game.Repositories
{
    using System;

    using Gamifyit.Game.Model;

    public class InMemoryGameTypeRepository : GenericInMemoryEntityRepository<GameType, ModelState.GameType>, IGameTypeRepository
    {
        protected override GameType EntityFactory(ModelState.GameType state)
        {
            return new GameType(state);
        }
    }
}