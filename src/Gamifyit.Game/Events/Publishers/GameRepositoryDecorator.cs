namespace Gamifyit.Game.Events.Publishers
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    public class GameRepositoryDecorator : IGameRepository
    {
        private readonly IGameRepository innerRepository;
        private readonly IEventMediator eventMediator;

        public GameRepositoryDecorator(IGameRepository innerRepository, IEventMediator eventMediator)
        {
            this.innerRepository = innerRepository;
            this.eventMediator = eventMediator;
        }

        public async Task Add(IGame game)
        {
            await this.innerRepository.Add(game);
            await this.eventMediator.Publish(new NewGameEvent(game));
        }

        public async Task<IGame> Get(EntityIdentity identity)
        {
            return await this.innerRepository.Get(identity);
        }
    }
}