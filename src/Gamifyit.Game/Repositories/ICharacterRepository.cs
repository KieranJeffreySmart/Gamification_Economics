namespace Gamifyit.Game.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public interface ICharacterRepository
    {
        Task Add(Character character);

        Task<Character> Get(EntityIdentity identity);
    }
}