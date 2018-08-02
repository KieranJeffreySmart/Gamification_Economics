namespace Gamifyit.Game.Publishers
{
    using System.Threading.Tasks;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
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

        public async Task Add(GameType gameType)
        {
            await this.innerRepository.Add(gameType);
            await this.eventMediator.Publish(new NewGameTypeEvent(gameType.Identity));
        }

        public async Task<GameType> Get(EntityIdentity identity)
        {
            return await this.innerRepository.Get(identity);
        }
    }
}