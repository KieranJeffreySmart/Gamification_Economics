namespace Gamifyit.Finance.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Finance.Model;
    using Gamifyit.Framework.DomainObjects;

    public interface IAccountRepository
    {
        Task<Account> Get(EntityIdentity accountId);
    }
}