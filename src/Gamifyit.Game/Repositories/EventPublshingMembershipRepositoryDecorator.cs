namespace Gamifyit.Game.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;

    public class EventPublshingMembershipRepositoryDecorator : IMembershipRepository
    {
        private readonly IMembershipRepository innerRepository;
        private readonly IEventMediator eventMediator;

        public EventPublshingMembershipRepositoryDecorator(IMembershipRepository innerRepository, IEventMediator eventMediator)
        {
            this.innerRepository = innerRepository;
            this.eventMediator = eventMediator;
        }

        public async Task Add(Membership membership)
        {
            await this.innerRepository.Add(membership);
            await this.eventMediator.Publish(new MembershipCreatedEvent(membership));
        }

        public Task<Membership> GetByEmailAddress(string email)
        {
            return this.innerRepository.GetByEmailAddress(email);
        }

        public Task<Membership> GetByUsername(string username)
        {
            return this.innerRepository.GetByUsername(username);
        }
    }
}