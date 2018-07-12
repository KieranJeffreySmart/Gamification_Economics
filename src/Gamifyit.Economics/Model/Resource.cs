namespace Gamifyit.Economics.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Resource : Entity<ModelState.Resource>
    {
        public Resource(ModelState.Resource state) : base(state)
        {
        }
    }
}
