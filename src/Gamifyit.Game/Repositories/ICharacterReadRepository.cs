namespace Gamifyit.Game.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public interface ICharacterReadRepository
    {
        Task<ICharacter> Get(EntityIdentity characterId);
    }
}