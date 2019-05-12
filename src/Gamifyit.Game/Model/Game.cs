namespace Gamifyit.Game.Model
{
    using System.Linq;
    using System.Threading.Tasks;
    using Gamifyit.Framework.DomainObjects;

    public class Game : Entity<ModelState.Game>, IGame
    {
        private readonly ValueObjectCollection<EntityIdentity, StateIdentity> characters;
        private readonly ValueObjectCollection<EntityIdentity, StateIdentity> players;

        public Game(ModelState.Game state)
            : base(state)
        {
            this.GameType = new GameType(state.Type);
            this.characters = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Characters, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
            this.players = new ValueObjectCollection<EntityIdentity, StateIdentity>(this.State.Players, EntityIdentity.StateFactory, EntityIdentity.ValueObjectFactory);
        }

        public GameType GameType { get; }

        public async Task StartNewGame()
        {
            this.players.Clear();
            await Task.FromResult(0);
        }

        public async Task JoinAsPlayer(EntityIdentity characterIdentity)
        {
            if (!this.characters.Contains(characterIdentity))
            {
                this.characters.Add(characterIdentity);
            }

            this.players.Add(characterIdentity);
            await Task.FromResult(0);
        }
    }
}