using System.Threading.Tasks;

namespace SpaceTrader.Framework.DomainObjects
{
    public abstract class EntityState
    {
        public StateIdentity Identity { get; set; }
    }
}
