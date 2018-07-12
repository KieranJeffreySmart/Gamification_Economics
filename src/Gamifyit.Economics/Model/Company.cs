namespace Gamifyit.Economics.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Company : Entity<ModelState.Company>
    {
        public Company(ModelState.Company state) : base(state)
        {
        }

        Business Business { get; set; }
    }
}
