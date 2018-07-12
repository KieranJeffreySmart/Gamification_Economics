namespace Gamifyit.Economics.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Deal : Entity<ModelState.Deal>
    {
        public Deal(ModelState.Deal state) : base(state)
        {
        }
    }
}
