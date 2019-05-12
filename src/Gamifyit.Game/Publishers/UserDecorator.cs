namespace Gamifyit.Game.Publishers
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
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
            await this.eventMediator.Publish(new UserRegisteredEvent(this.user.Identity));
        }

        public EntityIdentity Identity => this.user.Identity;
    }

    public class GameDecorator : IGame
    {
        private readonly IGame innerGame;

        private readonly IEventMediator eventMediator;

        public GameDecorator(IGame innerGame, IEventMediator eventMediator)
        {
            this.innerGame = innerGame;
            this.eventMediator = eventMediator;
        }

        public EntityIdentity Identity => this.innerGame.Identity;

        public GameType GameType => this.innerGame.GameType;

        public async Task StartNewGame()
        {
            await this.innerGame.StartNewGame();
        }

        public async Task JoinAsPlayer(EntityIdentity characterIdentity)
        {
            await this.innerGame.JoinAsPlayer(characterIdentity);
            await this.eventMediator.Publish(new PlayerHasJoinedGameEvent(characterIdentity, this.Identity));
        }
    }
}