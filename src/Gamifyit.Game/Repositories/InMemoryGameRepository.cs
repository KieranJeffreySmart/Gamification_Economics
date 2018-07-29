namespace Gamifyit.Game.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public class InMemoryGameRepository : IGameRepository
    {
        private readonly Dictionary<long, IGame> games = new Dictionary<long, IGame>();

        public async Task Add(IGame game)
        {
            await Task.Run(() => this.games.Add(game.Identity.Index, game));
        }

        public async Task<IGame> Get(EntityIdentity identity)
        {
            return await Task.Run(() => this.games.TryGetValue(identity.Index, out var game) ? game : null);
        }
    }
}