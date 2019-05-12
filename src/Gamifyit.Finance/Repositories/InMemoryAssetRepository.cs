namespace Gamifyit.Finance.Repositories
{
    using System.Threading.Tasks;

    using Gamifyit.Finance.Model;
    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Framework.Patterns;

    public class InMemoryAssetRepository : IAssetRepository
    {
        private readonly GenericInMemoryEntityRepository<Asset, ModelState.Asset> inMemoryStore;

        public InMemoryAssetRepository()
        {
            this.inMemoryStore = new GenericInMemoryEntityRepository<Asset, ModelState.Asset>((state) => new Asset(state));
        }

        public async Task<Asset> Get(EntityIdentity assetId)
        {
            return await this.inMemoryStore.Get(assetId);
        }
    }
}