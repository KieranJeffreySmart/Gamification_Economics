namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    internal class TestUser: User
    {
        public TestUser(Game.ModelState.User state, IMembershipRepository membershipRepository, IEventMediator eventMediator)
            : base(state, membershipRepository, eventMediator)
        {
        }

        protected TestUser(Game.ModelState.User state)
            : base(state)
        {
        }
    }
}