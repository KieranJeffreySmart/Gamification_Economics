namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Game.Publishers;

    using GameModel = Gamifyit.Game.Model;
    using GameState = Gamifyit.Game.ModelState;
    using GameEvents = Gamifyit.Game.Events;
    using GameRepositories = Gamifyit.Game.Repositories;

    using FinanceModel = Gamifyit.Finance.Model;
    using FinanceRepositories = Gamifyit.Finance.Repositories;

    public class GalacticStartupGameTest : WebsiteTest
    {
        protected readonly GameRepositories.IGameTypeRepository GameTypeRepository;
        protected readonly GameRepositories.IGameRepository GameRepository;
        protected readonly FinanceRepositories.ICurrencyRepository CurrencyRepository;

        protected readonly GameRepositories.ICharacterReadRepository CharacterReadRepository;
        protected readonly GalacticStartupTestData TestData = new GalacticStartupTestData();

        protected Func<Gamifyit.Game.ModelState.Game, Gamifyit.Game.Model.IGame> GameFactory { get; }

        public GalacticStartupGameTest()
        {
            this.GameTypeRepository = this.Dependancy.GetService<GameRepositories.IGameTypeRepository>();
            this.GameRepository = this.Dependancy.GetService<GameRepositories.IGameRepository>();
            this.CurrencyRepository = this.Dependancy.GetService<FinanceRepositories.ICurrencyRepository>();
            this.GameFactory = (state) => new GameDecorator(new GameModel.Game(state), this.EventMediator);
        }
        
        protected async Task HaveCreatedGame()
        {
            await this.CurrencyRepository.Add(new FinanceModel.Currency(this.TestData.Sterling));
            await this.GameTypeRepository.Add(new GameModel.GameType(this.TestData.GameType));
            await this.GameRepository.Add(this.GameFactory(this.TestData.Game));
        }

        protected async Task<GameModel.IGame> OpenGame()
        {
            var newEvent = this.ListEventHandler.Events.OfType<GameEvents.NewGameEvent>().FirstOrDefault();
            return await this.GameRepository.Get(newEvent?.Game);
        }
    }
}