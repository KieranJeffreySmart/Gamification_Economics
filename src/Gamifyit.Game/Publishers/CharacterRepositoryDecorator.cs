namespace Gamifyit.Game.Publishers
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    public class CharacterRepositoryDecorator : ICharacterRepository
    {
        private readonly ICharacterRepository innerRepository;
        private readonly IEventMediator eventMediator;

        public CharacterRepositoryDecorator(ICharacterRepository innerRepository, IEventMediator eventMediator)
        {
            this.innerRepository = innerRepository;
            this.eventMediator = eventMediator;
        }

        public async Task Add(Character character)
        {
            await this.innerRepository.Add(character);
            await this.eventMediator.Publish(new NewCharacterEvent(character.Identity));
        }

        public async Task<Character> Get(EntityIdentity identity)
        {
            return await this.innerRepository.Get(identity);
        }
    }
}