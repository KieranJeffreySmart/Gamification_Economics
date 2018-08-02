namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Publishers;
    using Gamifyit.Game.Repositories;

    using Xbehave;

    public class RegisterAsMemberFeature : WebsiteTest
    {
        readonly Func<TestUser> userFactory;
        IMembershipRepository membershipRepository;
        
        private IUser user;

        public RegisterAsMemberFeature()
        {
            this.membershipRepository = this.Dependancy.GetService<IMembershipRepository>();
            this.userFactory = () => new TestUser(new UserDecorator(
                new User(new Gamifyit.Game.ModelState.User(), this.membershipRepository), 
                this.EventMediator));
        }

        [Background]
        public void IAmAUserOnAWebsite()
        {
            "Given I am a user"
                .x(() => this.user = this.userFactory());

            "And I am on a website"
                .x(async () => await this.SetupWebsite());
        }

        [Scenario]
        public void RegisterAsMember(string emailAddress, string username)
        {
            "And I have an email address"
                .x(() => emailAddress = "me@myemail.com");

            "And I have a valid username"
                .x(() => username = "me");

            "When I register as a new member"
                .x(async () => await this.user.Register(emailAddress, username));

            "Then I should receive confirmation of my new membership"
                .x(() => this.NewMembershipNotificationReceived());

            "And User Registeration has completed"
                .x(() => this.UserHasRegistered());

            "And I can log into my Membership account using my email"
                .x(() => this.CanGetMembershipByEmail(emailAddress));

            "And I can log into my Membership account using my username"
                .x(() => this.CanGetMembershipByUsername(username));
        }

        private async Task SetupNotificationListner()
        {
            await this.EventMediator.Register(this.listEventHandler);
        }

        private void CanGetMembershipByUsername(string username)
        {
            this.membershipRepository.GetByUsername(username);
        }

        private void CanGetMembershipByEmail(string email)
        {
            this.membershipRepository.GetByEmailAddress(email);
        }

        private void UserHasRegistered()
        {
            this.listEventHandler.Events.OfType<UserRegisteredEvent>().Should().HaveCount(1);
        }

        private void NewMembershipNotificationReceived()
        {
            this.listEventHandler.Events.OfType<NewMembershipEvent>().Should().HaveCount(1);
        }
    }
}