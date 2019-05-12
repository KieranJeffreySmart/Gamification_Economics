namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests.Scenarios
{
    using System.Threading.Tasks;

    using Gamifyit.Game.Events;
    using Gamifyit.Game.Repositories;

    using Xbehave;

    public class CreateCharacterFeature: WebsiteTest
    {

        private ICharacterRepository characterRepository;
        private GalacticStartupTestData testData = new GalacticStartupTestData();

        [Background]
        public void Setup()
        {
            "And I am in the application"
                .x(async () => await this.SetupApplication());
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
                .x(async () => await this.CreateCharacter("Margaman", sex, type));

            "Then I am notified that my character was created successfully"
                .x(() => this.AmNotifiedOfEvent<NewCharacterEvent>());
        }

        private async Task CreateCharacter(string name, int sex, int type)
        {
            await this.characterRepository.Add(this.testData.MyFirstCharacter(name, sex, type));
        }
    }
}