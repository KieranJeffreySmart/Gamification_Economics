namespace Gamifyit.Game.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Game.Model;

    public interface IMembershipRepository
    {
        Task Add(Membership membership);

        Task<Membership> GetByEmailAddress(string email);

        Task<Membership> GetByUsername(string username);
    }
}
