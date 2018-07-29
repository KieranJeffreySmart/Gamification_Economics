namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;
    using Gamifyit.Geography.ModelState;

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
            "And I am on a website"
                .x(() => this.SetupWebsite().Wait());
        }

        [Scenario]
        public void CreateAGameType(
            string name,
            Universe universe,
            GameType gameType)
        {
            Dictionary<LookupItem, IList<LookupItem>> characterAttributes = new Dictionary<LookupItem, IList<LookupItem>>();
            
            "Given I have a name"
                .x(() => name = this.testData.GameTypeName);
            "And there are some Character Types"
                .x(() => characterAttributes.Add(this.testData.CharacterTypeAttributeLookup, this.testData.CharacterTypes.ToList()));
            "And there are some Character Sexes"
                .x(() => characterAttributes.Add(this.testData.CharacterSexesAttributeLookup, this.testData.CharacterSexes.ToList()));

            "When I create a new Game Type".x(() => this.CreateNewGameType(name, characterAttributes).Wait());

            "Then I am notified of a new game type".x(() => this.IAmNotifiedOfEvent<NewGameTypeEvent>());
        }

        private async Task CreateNewGameType(string name, Dictionary<LookupItem, IList<LookupItem>> characterAttributes)
        {
            var gameType = new GameType(new Gamifyit.Game.ModelState.GameType { LookupItem = new LookupItem { Value = name }, CharacterAttributes = characterAttributes });
            await this.gameTypeRepository.Add(gameType);
        }
    }
}