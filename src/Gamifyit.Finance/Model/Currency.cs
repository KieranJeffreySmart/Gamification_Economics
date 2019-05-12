namespace Gamifyit.Finance.Model
{
    using Gamifyit.Framework.DomainObjects;
    public class Currency : Entity<ModelState.Currency>
    {
        public Currency(ModelState.Currency state)
            : base(state)
        {
        }

        public string Name => this.State.Name;
    }
}