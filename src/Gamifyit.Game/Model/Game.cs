namespace Gamifyit.Game.Model
{
    using System.Threading.Tasks;
    using Gamifyit.Framework.DomainObjects;

    public class Game : Entity<ModelState.Game>, IGame
    {
        private readonly ValueObjectCollection<EntityIdentity, StateIdentity> characters;

        public Game(ModelState.Game state)
            : base(state)
        {

        }

        public async Task StartNewGame()
        {
            await Task.FromResult(0);
        }

        public Task AddCharacter(EntityIdentity characterIdentity)
        {
            throw new System.NotImplementedException();
        }
    }
}