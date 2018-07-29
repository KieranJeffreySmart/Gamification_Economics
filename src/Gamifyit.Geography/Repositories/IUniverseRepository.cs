namespace Gamifyit.Geography.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Geography.Model;

    public interface IUniverseRepository
    {
        Task<Universe> Get(string id);
    }
}