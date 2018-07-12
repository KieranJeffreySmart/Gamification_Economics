namespace Gamifyit.Game.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;

    public class InMemoryMembershipRepository: IMembershipRepository
    {
        private readonly List<Membership> memberships = new List<Membership>();

        public async Task Add(Membership membership)
        {
            await Task.Run(() => this.memberships.Add(membership));
        }
    }

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
    }
}
