namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    using Microsoft.Extensions.DependencyInjection;

    using Xbehave;

    public class QuickStartFeature
    {
        readonly Func<TestUser> userFactory;
        IEventMediator eventMediator;
        IMembershipRepository membershipRepository;

        private readonly ListEventHandler listEventHandler = new ListEventHandler();

        private ILookupRepository lookupRepository;

        private User user;

        public QuickStartFeature()
        {
            this.membershipRepository = Dependancy.Provider.GetService<IMembershipRepository>();
            this.eventMediator = Dependancy.Provider.GetService<IEventMediator>();
            this.lookupRepository = Dependancy.Provider.GetService<ILookupRepository>();
            this.userFactory = () => new TestUser(new Game.ModelState.User(), this.membershipRepository, this.eventMediator);

        }

        [Background]
        public void IAmAUserOnAWebsite()
        {
            "Given I am a user"
                .x(() => this.user = this.userFactory());

            "And I am on a website"
                .x(() => this.SetupNotificationListner().Wait());
        }

        [Scenario]
        public void RegisterAsMember(string emailAddress, string username)
        {
            "And I have an email address"
                .x(() => emailAddress = "me@myemail.com");

            "And I have a valid username"
                .x(() => username = "me");

            "When I register as a new member"
                .x(() => user.Register(emailAddress, username).Wait());

            "Then I should receive confirmation of my new membership"
                .x(() => this.NewMembershipNotificationReceived());

            "And User Registeration has completed"
                .x(() => this.UserHasRegistered());

            "And I can log into my Membership account using my email"
                .x(() => this.CanGetMembershipByEmail(emailAddress));

            "And I can log into my Membership account using my username"
                .x(() => this.CanGetMembershipByUsername(username));
        }

        [Scenario]
        public void CreateMyFirstCharacter(string characterName, LookupItem sex, LookupItem type)
        {
            "Given I have a membership"
                .x(() => this.CreateMembership("me@myemail.com", "me").Wait());
            
            "And I have selected a sex for my character"
                .x(() => sex = this.lookupRepository.Get(typeof(CharacterSex), 1));

            "And I have selected a sex for my character"
                .x(() => type = this.lookupRepository.Get(typeof(CharacterType), 1));

            "When I submit my new Character Margaman"
                .x(() => this.CreateCharacterForMember("Margaman", sex, type, "me").Wait());
            
            "Then I am notified that my character was created successfully"
                .x(() => this.IAmNotifiedThatMyCharacterWasCreatedSuccessfuly());

            "And a new Personal Account has opened called Wallet"
                .x(() => this.ANewPersonalAccountHasOpened());

            "And I am notified of funds into my account"
                .x(() => this.IAmNotifiedOfFundsIntoMyAccount());

            "And I am notified of Assets attained"
                .x(() => this.IAmNotifiedOfAssetsAttained());

            "And I am notified my current Net Worth has increased to 200C"
                .x(() => this.IAmNotifiedMyCurrentNetWorthHasIncreasedTo(200, "C"));

            "And I can view my account"
                .x(() => this.ICanViewMyAccount());

            "And I can view my Assets"
                .x(() => this.ICanViewMyAssets());
        }

        private void ICanViewMyAssets()
        {
            throw new NotImplementedException();
        }

        private void ICanViewMyAccount()
        {
            throw new NotImplementedException();
        }

        private void IAmNotifiedMyCurrentNetWorthHasIncreasedTo(int amount, string currencyId)
        {
            throw new NotImplementedException();
        }

        private void IAmNotifiedOfAssetsAttained()
        {
            throw new NotImplementedException();
        }

        private void IAmNotifiedOfFundsIntoMyAccount()
        {
            throw new NotImplementedException();
        }

        private void ANewPersonalAccountHasOpened()
        {
            throw new NotImplementedException();
        }

        [Scenario]
        public void SelectStartingLocation()
        {
            "Given there is a Universe"
                .x(() => throw new NotImplementedException());
            "And there is a Galaxy"
                .x(() => throw new NotImplementedException());
            "And there is a Solar System"
                .x(() => throw new NotImplementedException());
            "And there is a Planet"
                .x(() => throw new NotImplementedException());
            "And there is a City"
                .x(() => throw new NotImplementedException());
            "When I submit my Location"
                .x(() => throw new NotImplementedException());
            "Then I am notified that my starting location has been set"
                .x(() => throw new NotImplementedException());
        }

        [Scenario]
        public void MakeFirstDeal()
        {
            "Given there is a Business of the type Real Estate with the name Mom And Dad"
                .x(() => throw new NotImplementedException());
            "And the Business Mom And Dad has a Property of the type Modest Family Home"
                .x(() => throw new NotImplementedException());
            "And the Business Mom And Dad has submitted a Rental Proposal for 0C PCM"
                .x(() => throw new NotImplementedException());
            "When I accept the Proposal"
                .x(() => throw new NotImplementedException());
            "Then I am informed a Deal of the type Tenancy Agreement has been Made"
                .x(() => throw new NotImplementedException());
            "I win an Award for Making My First Deal"
                .x(() => throw new NotImplementedException());
        }

        [Scenario]
        public void CreateFirstBusiness()
        {
            "Given I have a business name"
                .x(() => throw new NotImplementedException());
            "And an Address"
                .x(() => throw new NotImplementedException());
            "And there is an Agency that handles New Business Applications"
                .x(() => throw new NotImplementedException());
            "When I Submit an Application for a New Business"
                .x(() => throw new NotImplementedException());
            "Then I am notified that the application was successful"
                .x(() => throw new NotImplementedException());
            "I win an Award for Creting My First Business"
                .x(() => throw new NotImplementedException());
        }

        [Scenario]
        public void PayMyFirstInvoice()
        {
            "Given I have a business"
                .x(() => throw new NotImplementedException());
            "Given there is an outstanding Invoice against the Business"
                .x(() => throw new NotImplementedException());
            "And there is an Account called Wallet with 100 C"
                .x(() => throw new NotImplementedException());
            "When I Pay the Invoice using my Account Wallet"
                .x(() => throw new NotImplementedException());
            "Then the Balance on my Account Wallet should be reduced to 40 C"
                .x(() => throw new NotImplementedException());
            "I win an Award for Making My First Invoice Paid"
                .x(() => throw new NotImplementedException());
        }

        private void IAmNotifiedThatMyCharacterWasCreatedSuccessfuly()
        {
            this.listEventHandler.Events.OfType<CharacterCreatedEvent>().Should().HaveCount(1);
        }

        private async Task CreateCharacterForMember(string name, LookupItem sex, LookupItem type, string email)
        {
            var membership = await this.membershipRepository.GetByEmailAddress(email);
            membership.Member.AddCharacter(new Character(new Game.ModelState.Character {Sex = sex, Type = type, Name = name }));
        }

        private async Task CreateMembership(string emailAddress, string username)
        {
            var user = this.userFactory();
            await this.SetupNotificationListner();
            await user.Register(emailAddress, username);
            user.Membership.Should().NotBeNull();
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
            this.listEventHandler.Events.OfType<MembershipCreatedEvent>().Should().HaveCount(1);
        }

        private async Task SetupNotificationListner()
        {
            await this.eventMediator.Register(this.listEventHandler);
        }
    }

    public interface ILookupRepository
    {
        LookupItem Get(Type type, int key);
    }
}
