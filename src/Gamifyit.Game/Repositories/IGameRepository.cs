namespace Gamifyit.Game.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public interface IGameRepository
    {
        Task Add(IGame game);

        Task<IGame> Get(EntityIdentity identity);
    }
}