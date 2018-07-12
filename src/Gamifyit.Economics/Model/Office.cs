namespace Gamifyit.Economics.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Office : Entity<ModelState.Office>
    {
        public Office(ModelState.Office state) : base(state)
        {
        }
    }
}
