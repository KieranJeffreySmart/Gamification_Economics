namespace Gamifyit.Game.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public interface IGameTypeRepository
    {
        Task Add(GameType game);

        Task<GameType> Get(EntityIdentity identity);
    }
}