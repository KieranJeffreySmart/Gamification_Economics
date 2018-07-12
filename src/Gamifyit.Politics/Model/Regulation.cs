namespace Gamifyit.Politics.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Regulation : Entity<ModelState.Regulation>
    {
        public Regulation(ModelState.Regulation state) : base(state)
        {
        }
    }
}
