namespace Gamifyit.Finance.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Finance.Model;
    using Gamifyit.Framework.DomainObjects;

    public interface IAssetRepository
    {
        Task<Asset> Get(EntityIdentity assetId);
    }
}