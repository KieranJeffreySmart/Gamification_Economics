namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    using Xbehave;

    public class CreateGameFeature : WebsiteTest
    {
        private IGameRepository gameRepository;
        GalacticStartupTestData testData = new GalacticStartupTestData();

        public CreateGameFeature()
        {
            this.gameRepository = this.Dependancy.GetService<IGameRepository>();
        }


        [Background]
        public void Setup()
        {
            "And I am in the application"
                .x(async () => await this.SetupApplication());
        }
        
        [Scenario]
        public void CreateGame(string name, int type, IGame game)
        {
            "Given I have a name"
                .x(() => name = "My First Game");

            "Given I have a game type"
                .x(() => type = this.testData.GameTypeLookup.Key);

            "When I create a new Game".x(async () => await this.CreateNewGame(name));

            "Then I am notified of a new game type".x(() => this.IAmNotifiedOfANewGame());
        }

        private async Task CreateNewGame(string name)
        {
            var game = new Game(new Gamifyit.Game.ModelState.Game { Name = name, Type = this.testData.GameTypeLookup.Key});
            await this.gameRepository.Add(game);
        }

        private void IAmNotifiedOfANewGame()
        {
            this.listEventHandler.Events.OfType<NewGameEvent>().Count().Should().Be(1);
        }
    }
}