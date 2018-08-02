namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    using Xbehave;

    using Game = Gamifyit.Game.Model.Game;
    using GameModelState = Gamifyit.Game.ModelState;
    using User = Gamifyit.Game.Model.User;

    public class QuickStartFeature: WebsiteTest
    {
        readonly Func<TestUser> userFactory;
        IMembershipRepository membershipRepository;

        private IGameRepository gameRepository;

        IGame game;

        private GalacticStartupTestData testData = new GalacticStartupTestData();

        public QuickStartFeature()
        {
            this.membershipRepository = this.Dependancy.GetService<IMembershipRepository>();
            this.userFactory = () => new TestUser(new User(new GameModelState.User(), this.membershipRepository));
            this.gameRepository = this.Dependancy.GetService<IGameRepository>();
        }
    
        [Background]
        public void IAmAUserOnAWebsite()
        {
            var email = "me@myemail.com";
            var userName = "me";
            var gameName = "My First Game";

            "Given I have a membership"
                .x(async () => await this.CreateMembership(email, userName));

            "And I have started a game"
                .x(async () => this.game = await this.StartGame(email, gameName));
        }

        [Scenario]
        public void SelectStartingLocation(string universeId, string galaxyId, string solarSystemId)
        {
            //"Given there is a Universe"
            //    .x(() => universeId = this.geographyService.GetAllUniverseSummaries());
            //"And there is a Galaxy"
            //    .x(() => galaxyId = this.myFirstGalaxyId);
            //"And there is a Solar System"
            //    .x(() => solarSystemId = this.myFirstSolarSystemId);
            //"And there is a Planet"
            //    .x(() => planetId = this.myFirstPlanetId);
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

        private async Task CreateMembership(string emailAddress, string username)
        {
            var user = this.userFactory();
            await user.Register(emailAddress, username);
            user.Identity.Should().NotBeNull();
        }
        
        private async Task<IGame> StartGame(string membersReference, string gameName)
        {
            var game = new Game(new GameModelState.Game() { Name = gameName, Type = 1 });
            await this.gameRepository.Add(game);
            var membership = await this.membershipRepository.GetByEmailAddress(membersReference);
            membership.Member.AddGame(game.Identity);
            return game;
        }
    }
}
