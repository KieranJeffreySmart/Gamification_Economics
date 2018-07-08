using SpaceTrader.Framework.DomainObjects;

namespace SpaceTrader.Model
{
    public class Location
    {
        public EntityIdentity Universe { get; }
        public EntityIdentity Galaxy { get; }
        public EntityIdentity SolarSystem { get; }
        public EntityIdentity Planet { get; }
        public EntityIdentity City { get; }
        public EntityIdentity Address { get; }
    }
}
