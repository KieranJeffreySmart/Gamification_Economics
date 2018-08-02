namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    using Xbehave;

    public class CreateAGameTypeFeature : WebsiteTest
    {
        private readonly GalacticStartupTestData testData = new GalacticStartupTestData();

        private readonly IGameTypeRepository gameTypeRepository;
        
        public CreateAGameTypeFeature()
        {
            this.gameTypeRepository = this.Dependancy.GetService<IGameTypeRepository>();
        }

        [Background]
        public void Setup()
        {
            "And I am in the application"
                .x(async () => await this.SetupApplication());
        }

        [Scenario]
        public void CreateAGameType(
            string name)
        {
            Dictionary<LookupItem, List<LookupItem>> characterAttributes = new Dictionary<LookupItem, List<LookupItem>>();
            
            "Given I have a name"
                .x(() => name = this.testData.GameTypeName);
            "And there are some Character Types"
                .x(() => characterAttributes.Add(this.testData.CharacterTypeAttributeLookup, this.testData.CharacterTypes.ToList()));
            "And there are some Character Sexes"
                .x(() => characterAttributes.Add(this.testData.CharacterSexesAttributeLookup, this.testData.CharacterSexes.ToList()));

            "When I create a new Game Type".x(async () => await this.CreateNewGameType(name, characterAttributes));

            "Then I am notified of a new game type".x(() => this.IAmNotifiedOfEvent<NewGameTypeEvent>());
        }

        [Scenario]
        public void CreateManyGameType(string name1, string name2)
        {
            Dictionary<LookupItem, List<LookupItem>> characterAttributes = new Dictionary<LookupItem, List<LookupItem>>();

            "Given I have two name {name1} and {name2}"
                .x(() =>
                        {
                            name1 = "name1";
                            name2 = "name2";
                        });
            "And there are some Character Types"
                .x(() => characterAttributes.Add(this.testData.CharacterTypeAttributeLookup, this.testData.CharacterTypes.ToList()));
            "And there are some Character Sexes"
                .x(() => characterAttributes.Add(this.testData.CharacterSexesAttributeLookup, this.testData.CharacterSexes.ToList()));

            "When I create a new Game Type"
                .x(async () => await this.CreateNewGameTypes(new Gamifyit.Game.ModelState.GameType[]
                                                                 {
                                                                     this.NewState(characterAttributes, name1),
                                                                     this.NewState(characterAttributes, name2)
                                                                 }));

            "Then I am notified of a new game type".x(() => this.IAmNotifiedOfEvent<NewGameTypeEvent>(2));
        }

        private async Task CreateNewGameTypes(Gamifyit.Game.ModelState.GameType[] gameTypeStates)
        {
            foreach (var gameTypeState in gameTypeStates)
            {
                var gameType = new GameType(gameTypeState);
                await this.gameTypeRepository.Add(gameType);
            }
        }

        private Gamifyit.Game.ModelState.GameType NewState(Dictionary<LookupItem, List<LookupItem>> characterAttributes, string name)
        {
            return new Gamifyit.Game.ModelState.GameType { LookupItem = new LookupItem { Value = name }, CharacterAttributes = characterAttributes };
        }

        private async Task CreateNewGameType(string name, Dictionary<LookupItem, List<LookupItem>> characterAttributes)
        {
            var gameType = new GameType(this.NewState(characterAttributes, name));
            await this.gameTypeRepository.Add(gameType);
        }
    }
}