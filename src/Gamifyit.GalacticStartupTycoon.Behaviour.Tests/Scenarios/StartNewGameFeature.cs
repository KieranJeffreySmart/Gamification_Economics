namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;

    using Xbehave;

    public class StartNewGameFeature : GalacticStartupGameTest
    {
        private EntityIdentity characterId;

        [Background]
        public void SetUp()
        {
            "Given I am in the application".x(async () => await this.SetupApplication());

            "And I Have a New Game".x(async () => await this.HaveCreatedGame());
        }

        [Scenario]
        public void StartNewGame(IGame game, EntityIdentity characterId)
        {
            "Given I have opened a game".x(async () => game = await this.OpenGame());

            "And a created character".x(() => characterId = new EntityIdentity(new StateIdentity(1, Guid.NewGuid().ToString())));

            "When I add the character to the game"
                .x(async () => await this.AddChacterToGame(game, characterId));

            "Then I am notified my character has joined a game"
                .x(() => this.IAmNotifiedOfEvent<CharacterHasJoinedGameEvent>());

            "And a new Personal Account has opened called Wallet"
                .x(() => this.IAmNotifiedOfEvent<NewPersonalAccountOpenedEvent>());

            "And I am notified of funds into my account"
                .x(() => this.IAmNotifiedOfFundsIntoMyAccount());

            "And I am notified of Assets attained"
                .x(() => this.IAmNotifiedOfAssetsAttained());

            "And I am notified my current Net Worth has increased to 200C"
                .x(() => this.IAmNotifiedMyCurrentNetWorthHasIncreasedTo(200, "C"));
            
            "And I can view my characters Assets"
                .x(async () => await this.ICanViewMyCharactersAssets());
        }


        private async Task AddChacterToGame(IGame game, EntityIdentity characterId)
        {
            await game.AddCharacter(characterId);
        }

        private void IAmNotifiedMyCharacterHasJoinedAGame()
        {
        }

        private async Task ICanViewMyCharactersAssets()
        {
            throw new System.NotImplementedException();
        }

        private void ICanViewMyAssets()
        {
            throw new System.NotImplementedException();
        }

        private void ICanViewMyAccount()
        {
            throw new System.NotImplementedException();
        }

        private void IAmNotifiedMyCurrentNetWorthHasIncreasedTo(int i, string s)
        {
            throw new System.NotImplementedException();
        }

        private void IAmNotifiedOfAssetsAttained()
        {
            throw new System.NotImplementedException();
        }

        private void IAmNotifiedOfFundsIntoMyAccount()
        {
            throw new System.NotImplementedException();
        }

        private void ANewPersonalAccountHasOpened()
        {
            throw new System.NotImplementedException();
        }

    }
}