namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;
    using GameModelState = Game.ModelState;



    internal class TestUser : IUser
    {
        private readonly IUser user;

        public TestUser(IUser user)
        {
            this.user = user;
        }

        public EntityIdentity Identity => this.user.Identity;

        public async Task Register(string email, string username)
        {
            await user.Register(email, username);
        }
    }
}