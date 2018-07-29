namespace Gamifyit.Game.Events.Publishers
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;

    public class UserDecorator : IUser
    {
        private readonly IUser user;
        private readonly IEventMediator eventMediator;

        public UserDecorator(IUser user, IEventMediator eventMediator)
        {
            this.user = user;
            this.eventMediator = eventMediator;
        }

        public async Task Register(string email, string username)
        {
            await this.user.Register(email, username);
            await this.eventMediator.Publish(new UserRegisteredEvent(this.user));
        }

        public EntityIdentity Identity => this.user.Identity;
    }
}