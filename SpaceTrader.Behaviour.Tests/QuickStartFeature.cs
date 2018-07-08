using SpaceTrader.Framework;
using SpaceTrader.Model;
using SpaceTrader.Repositories;
using System;
using Xbehave;

namespace SpaceTrader.Behaviour.Tests
{
    public class QuickStartFeature
    {
        Func<User> userFactory;
        IEventMediator eventMediator = new EventMediator();
        IMembershipRepository membershipRepository;

        public QuickStartFeature()
        {
            membershipRepository = new EventPublshingMembershipRepositoryDecorator(new InMemoryMembershipRepository(), this.eventMediator);
            userFactory = () => new User(new ModelState.User(), membershipRepository, eventMediator);
        }

        [Scenario]
        public void RegisterAsMember(string emailAddress, string username, User user)
        {
            "Given I am a user"
                .x(() => user = userFactory());

            "And I have an email address"
                .x(() => emailAddress = "me@myemail.com");

            "And I have a valid username"
                .x(() => username = "me");

            "When I register as a new member"
                .x(() => user.Register(emailAddress, username));

            "Then I should receive confirmation of my new membership"
                .x(() => );
        }
    }
}
