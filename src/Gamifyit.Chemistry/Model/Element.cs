namespace Gamifyit.Chemistry.Model
{
    using Gamifyit.Framework.DomainObjects;

    public class Element : Entity<ModelState.Element>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal AbundanceRatio { get; set; }

        public Element(ModelState.Element state)
            : base(state)
        {
        }
    }
}
