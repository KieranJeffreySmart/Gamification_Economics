namespace Gamifyit.Game.Events.Publishers
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    public class GameTypeRepositoryDecorator : IGameTypeRepository
    {
        private readonly IGameTypeRepository innerRepository;
        private readonly IEventMediator eventMediator;

        public GameTypeRepositoryDecorator(IGameTypeRepository innerRepository, IEventMediator eventMediator)
        {
            this.innerRepository = innerRepository;
            this.eventMediator = eventMediator;
        }

        public async Task Add(GameType game)
        {
            await this.innerRepository.Add(game);
            await this.eventMediator.Publish(new NewGameTypeEvent(game));
        }

        public async Task<GameType> Get(EntityIdentity identity)
        {
            return await this.innerRepository.Get(identity);
        }
    }
}