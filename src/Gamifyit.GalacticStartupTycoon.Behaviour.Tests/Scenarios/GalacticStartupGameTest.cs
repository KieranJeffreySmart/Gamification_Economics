namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    public class GalacticStartupGameTest : WebsiteTest
    {
        protected readonly IGameTypeRepository GameTypeRepository;
        protected readonly IGameRepository GameRepository;
        protected readonly GalacticStartupTestData TestData = new GalacticStartupTestData();

        public GalacticStartupGameTest()
        {
            this.GameTypeRepository = this.Dependancy.GetService<IGameTypeRepository>();
            this.GameRepository = this.Dependancy.GetService<IGameRepository>();
        }
        
        protected async Task HaveCreatedGame()
        {
            await this.GameTypeRepository.Add(new GameType(this.TestData.GameType));

            await this.GameRepository.Add(new Game(this.TestData.Game));
        }

        protected async Task<IGame> OpenGame()
        {
            var newEvent = this.listEventHandler.Events.OfType<NewGameEvent>().FirstOrDefault();
            return await this.GameRepository.Get(newEvent?.Game);
        }
    }
}