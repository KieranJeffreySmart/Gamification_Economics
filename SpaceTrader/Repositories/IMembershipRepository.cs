using SpaceTrader.Model;
using System.Threading.Tasks;

namespace SpaceTrader.Repositories
{
    public interface IMembershipRepository
    {
        Task Add(Membership membership);
    }
}
