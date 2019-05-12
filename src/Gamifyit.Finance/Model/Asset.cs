namespace Gamifyit.Finance.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Asset : Entity<Finance.ModelState.Asset>
    {
        public Asset(Finance.ModelState.Asset state)
            : base(state)
        {
        }
    }
}
