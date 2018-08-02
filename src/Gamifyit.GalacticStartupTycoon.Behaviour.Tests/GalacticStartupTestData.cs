namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.ModelState;
    using Gamifyit.Geography.ModelState;

    using Character = Gamifyit.Game.Model.Character;

    public class GalacticStartupTestData
    {
        public GalacticStartupTestData()
        {
            this.CharacterTypeAttributeLookup = new LookupItem { Key = 1, Value = nameof(this.CharacterTypes) };
            this.CharacterSexesAttributeLookup = new LookupItem { Key = 2, Value = nameof(this.CharacterSexes) };
            this.GameTypeLookup = new LookupItem { Key = 1, Value = nameof(this.GameTypes) };
            this.CharacterAttributes =
                new Dictionary<LookupItem, List<LookupItem>>
                    {
                        {
                            this.CharacterTypeAttributeLookup,
                            this.CharacterTypes
                        },
                        {
                            this.CharacterSexesAttributeLookup,
                            this.CharacterSexes
                        }
                    };

            this.GameType = new GameType { LookupItem = this.GameTypeLookup, CharacterAttributes = this.CharacterAttributes};
            this.Game = new Game { Name = gameName, Type = this.GameTypeLookup.Key };
        }

        public Dictionary<LookupItem, List<LookupItem>> CharacterAttributes { get; }

        public List<LookupItem> CharacterTypes { get; } =
            new List<LookupItem>
                {
                    new LookupItem { Key = 1, Value = "Business Graduate" },
                    new LookupItem { Key = 2, Value = "Homeless Bum" }
                };

        public List<LookupItem> CharacterSexes { get; } =
            new List<LookupItem>
                {
                    new LookupItem { Key = 1, Value = "Male" },
                    new LookupItem { Key = 2, Value = "Female" }
                };

        public IEnumerable<LookupItem> GameTypes { get; } =
            new List<LookupItem> { new LookupItem { Key = 1, Value = gameTypeName } };

        public City TheCity { get; set; }

        public Planet ThePlanet { get; set; }

        public SolarSystem TheSolarSystem { get; set; }

        public Galaxy TheGalaxy { get; set; }

        public Universe TheUniverse { get; set; }

        protected static string gameTypeName = "GalacticStartup";

        protected static string gameName = "MyFirstGame";

        public string GameTypeName { get; } = gameTypeName;

        public LookupItem CharacterTypeAttributeLookup { get; }

        public LookupItem CharacterSexesAttributeLookup { get; }

        public LookupItem GameTypeLookup { get; }

        public Game Game { get; }

        public GameType GameType { get; }

        public Character MyFirstCharacter(string name, int type, int sex) => new Character(
            new Gamifyit.Game.ModelState.Character
                {
                    Name = name,
                    Attributes =
                        new Dictionary<int, int>()
                            {
                                {
                                    this.CharacterTypeAttributeLookup.Key,
                                    type
                                },
                                {
                                    this.CharacterSexesAttributeLookup.Key,
                                    sex
                                }
                            }
                });
    }
}
