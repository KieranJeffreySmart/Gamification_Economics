namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentAssertions;

    using Gamifyit.Framework.Events;
    using Gamifyit.Game.Events;
    using Gamifyit.Game.Model;
    using Gamifyit.Game.Repositories;

    using Microsoft.Extensions.DependencyInjection;

    using Xbehave;

    public class CreateCharacterFeature: WebsiteTest
    {

        private ICharacterRepository characterRepository;
        private GalacticStartupTestData testData = new GalacticStartupTestData();

        [Background]
        public void Setup()
        {
            "And I am on a website"
                .x(() => this.SetupWebsite().Wait());
        }

        public CreateCharacterFeature()
        {
            this.characterRepository = this.Dependancy.GetService<ICharacterRepository>();
        }


        [Scenario]
        public void CreateMyFirstCharacter(string characterName, int sex, int type)
        {

            "And I have selected a sex for my character"
                .x(() => sex = 1);

            "And I have selected a sex for my character"
                .x(() => type = 1);

            "When I submit my new Character Margaman"
                .x(() => this.CreateCharacter("Margaman", sex, type).Wait());

            "Then I am notified that my character was created successfully"
                .x(() => this.IAmNotifiedOfEvent<NewCharacterEvent>());
        }

        private async Task CreateCharacter(string name, int sex, int type)
        {
            await this.characterRepository.Add(
                new Character(
                    new Gamifyit.Game.ModelState.Character
                    {
                        Name = name,
                        Attributes =
                                new Dictionary<int, int>()
                                    {
                                        {
                                            this.testData
                                                .CharacterTypeAttributeLookup
                                                .Key,
                                            type
                                        },
                                        {
                                            this.testData
                                                .CharacterSexesAttributeLookup
                                                .Key,
                                            sex
                                        }
                                    }
                    }));
        }
    }
}