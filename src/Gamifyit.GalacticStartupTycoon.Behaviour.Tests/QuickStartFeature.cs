namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;

    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    using Microsoft.Extensions.DependencyInjection;

    using Xbehave;

    public class QuickStartFeature
    {
        Func<User> userFactory;
        IEventMediator eventMediator = new EventMediator();
        IMembershipRepository membershipRepository;

        public QuickStartFeature()
        {
            this.membershipRepository = new EventPublshingMembershipRepositoryDecorator(new InMemoryMembershipRepository(), this.eventMediator);
            this.userFactory = () => new User(new Game.ModelState.User(), this.membershipRepository, this.eventMediator);
        }

        [Scenario]
        public void RegisterAsMember(string emailAddress, string username, User user)
        {
            "Given there is a notification framework"
                .x(() => SetupNotificationListner());

            "Given I am a user"
                .x(() => user = this.userFactory());

            "And I have an email address"
                .x(() => emailAddress = "me@myemail.com");

            "And I have a valid username"
                .x(() => username = "me");

            "When I register as a new member"
                .x(() => user.Register(emailAddress, username));

            "Then I should receive confirmation of my new membership"
                .x(() => NewMembershipNotificationReceived());
        }

        private void NewMembershipNotificationReceived()
        {
            throw new NotImplementedException();
        }

        private void SetupNotificationListner()
        {
            throw new NotImplementedException();
        }
    }

    public class Dependancy
    {
        private IServiceCollection Collection = new ServiceCollection();

        private IServiceProvider Provider;

        public void Setup()
        {
            this.Collection.AddTransient<IEventMediator, EventMediator>();
            this.Collection.AddTransient<IEventHandler<Event>, >();
            this.Provider = this.Collection.BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return this.Provider.GetService<T>();
        }
    }
}
