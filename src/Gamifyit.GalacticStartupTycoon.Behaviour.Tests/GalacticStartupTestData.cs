namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    using Gamifyit.Finance.ModelState;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.ModelState;
    using Gamifyit.Geography.ModelState;

    using Character = Gamifyit.Game.Model.Character;
    using Currency = Gamifyit.Finance.ModelState.Currency;

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

            this.sterling = new Currency
                                     {
                                         Name = "Sterling"
                                     };

            this.gameType = new GameType { LookupItem = this.GameTypeLookup, CharacterAttributes = this.CharacterAttributes, CurrencyTypes = this.CurrencyTypes };
            this.game = new Game { Name = gameName, Type = this.gameType };
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

        public List<LookupItem<long>> CurrencyTypes { get; } =
            new List<LookupItem<long>>
                {
                    new LookupItem<long> { Key = 1, Value = "GBP" },
                    new LookupItem<long> { Key = 2, Value = "USD" }
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

        private GameType gameType;

        private Game game;

        private Currency sterling;

        public string GameTypeName { get; } = gameTypeName;

        public LookupItem CharacterTypeAttributeLookup { get; }

        public LookupItem CharacterSexesAttributeLookup { get; }

        public LookupItem GameTypeLookup { get; }

        public Game Game => this.game.CloneAsSelf();

        public GameType GameType => this.gameType.CloneAsSelf();

        public Currency Sterling => this.sterling.CloneAsSelf();

        public Gamifyit.Game.ModelState.Currency InGameBritishPounds { get; }

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
