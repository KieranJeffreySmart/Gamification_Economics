namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Gamifyit.Finance.Events;
    using Gamifyit.Finance.Model;
    using Gamifyit.Finance.Repositories;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;

    using Xbehave;

    public class StartNewGameFeature : GalacticStartupGameTest
    {
        private IAccountRepository accountRepository;

        private IAssetRepository assetRepository;

        [Background]
        public void SetUp()
        {
            "Given I am in the application".x(async () => await this.SetupApplication());
            
            "And I Have a New Game".x(async () => await this.HaveCreatedGame());
        }

        [Scenario]
        public void StartNewGame(IGame game, EntityIdentity characterId, ICharacter character)
        {
            var personalAccountName = "Wallet";
            var currencyType = new LookupItem<long> { Key = 1, Value = "GBP" };
            var assetType = new LookupItem { Key = 1, Value = "Computer" };

            "Given I have opened a game".x(async () => game = await this.OpenGame());

            "And I have a created character".x(() => characterId = new EntityIdentity(new StateIdentity(1, Guid.NewGuid().ToString())));

            "When I join the game"
                .x(async () => await this.JoinGameAsPlayer(game, characterId));

            "Then I am notified my character has joined a game"
                .x(() => this.AmNotifiedOfEvent<PlayerHasJoinedGameEvent>());

            "And a new Personal Account has opened called {personalAccountName} with a total funds of 0 creits"
                .x(() => this.AmNotifiedOfEvent<NewPersonalAccountOpenedEvent>((l) => this.AssertNewPersonalAccountOpened(l, personalAccountName, 0, currencyType)));

            "And I am notified of funds into my account of 100 credits"
                .x(() => this.AmNotifiedOfEvent<FundsAddedToAccount>((l) => this.AssertFundsAddedToAccount(l, personalAccountName, 100, currencyType)));

            "And I am notified of Assets received of the type {assetType}"
                .x(() => this.AmNotifiedOfEvent<AssetsReceived>((l) => this.AssertAssetReceived(l, assetType)));

            "And I am notified my current Net Worth has increased to 200C"
                .x(() => this.AmNotifiedOfEvent<NetWorthIncreased>((l) => this.AssertCharactersNetWorth(l, characterId, 200, currencyType)));
            
            "And I can view my character"
                .x(async () => await this.ICanViewMyCharacter(characterId));

            "And I can view my characters Assets"
                .x(async () => await this.ICanViewMyAssets(character, game.GameType));

            "And I can view my characters accounts"
                .x(async () => await this.ICanViewMyAccount(character));
        }

        private void AssertFundsAddedToAccount(IEnumerable<FundsAddedToAccount> fundsAddedToAccounts, string personalAccountName, int i, LookupItem<long> currencyType)
        {
            var accountEvent = fundsAddedToAccounts.SingleOrDefault();
        }

        private void AssertNewPersonalAccountOpened(IEnumerable<NewPersonalAccountOpenedEvent> newPersonalAccountOpenedEvents, string personalAccountName, int i, LookupItem<long> currencyType)
        {
            throw new NotImplementedException();
        }

        private void AssertCharactersNetWorth(IEnumerable<NetWorthIncreased> l, EntityIdentity characterId, int expectedAmount, LookupItem<long> currencyType)
        {
            var expectedEbent = l.SingleOrDefault(e => e.CharacterId == characterId);
            expectedEbent.TotalNetWorth.Should().Be(expectedAmount);
        }

        private void AssertAssetReceived(IEnumerable<AssetsReceived> events, LookupItem assetType)
        {
        }

        private async Task JoinGameAsPlayer(IGame game, EntityIdentity characterId)
        {
            await game.JoinAsPlayer(characterId);
        }

        private async Task<ICharacter> ICanViewMyCharacter(EntityIdentity characterId)
        {
            var gameCharacter = await this.CharacterReadRepository.Get(characterId);
            gameCharacter.Should().NotBeNull();
            return gameCharacter;
        }

        private async Task ICanViewMyAssets(ICharacter character, GameType gameType)
        {
            character.Assets.Any().Should().BeTrue();
            foreach (var characterAsset in character.Assets)
            {
                var asset = await this.assetRepository.Get(characterAsset);
                asset.Should().NotBeNull();
            }
        }

        private async Task ICanViewMyAccount(ICharacter character)
        {
            character.Accounts.Any().Should().BeTrue();
            foreach (var characterAccount in character.Accounts)
            {
                var account = await this.accountRepository.Get(characterAccount);
                account.Should().NotBeNull();
            }
        }
    }
}