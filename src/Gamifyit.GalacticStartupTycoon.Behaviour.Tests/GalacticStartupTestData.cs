namespace Gamifyit.GalacticStartupTycoon.Behaviour.Tests
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Geography.ModelState;

    public class GalacticStartupTestData
    {
        public GalacticStartupTestData()
        {
            this.CharacterTypeAttributeLookup = new LookupItem { Key = 1, Value = nameof(this.CharacterTypes) };
            this.CharacterSexesAttributeLookup = new LookupItem { Key = 2, Value = nameof(this.CharacterSexes) };
            this.GameTypeLookup = new LookupItem { Key = 1, Value = nameof(this.GameTypes) };
        }

        public IEnumerable<LookupItem> CharacterTypes { get; } =
            new List<LookupItem>
                {
                    new LookupItem { Key = 1, Value = "Business Graduate" },
                    new LookupItem { Key = 2, Value = "Homeless Bum" }
                };

        public IEnumerable<LookupItem> CharacterSexes { get; } =
            new List<LookupItem>
                {
                    new LookupItem { Key = 1, Value = "Male" },
                    new LookupItem { Key = 2, Value = "Female" }
                };

        public IEnumerable<LookupItem> GameTypes { get; } =
            new List<LookupItem>
                {
                    new LookupItem { Key = 1, Value = gameTypeName }
                };

        public City TheCity { get; set; }

        public Planet ThePlanet { get; set; }

        public SolarSystem TheSolarSystem { get; set; }

        public Galaxy TheGalaxy { get; set; }

        public Universe TheUniverse { get; set; }

        protected static string gameTypeName = "MyFirstGame";

        public string GameTypeName { get; } = gameTypeName;

        public LookupItem CharacterTypeAttributeLookup { get; }

        public LookupItem CharacterSexesAttributeLookup { get; }

        public LookupItem GameTypeLookup { get; }
    }
}