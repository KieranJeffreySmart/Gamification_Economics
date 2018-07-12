namespace Gamifyit.Economics.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Facility : Entity<ModelState.Facility>
    {
        public Facility(ModelState.Facility state) : base(state)
        {
        }
    }
}
