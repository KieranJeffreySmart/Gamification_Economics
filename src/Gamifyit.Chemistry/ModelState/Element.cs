namespace Gamifyit.Chemistry.ModelState
{
    using Gamifyit.Framework.DomainObjects;

    public class Element : EntityState
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rarity { get; set; }
    }
}
