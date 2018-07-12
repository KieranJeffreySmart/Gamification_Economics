namespace Gamifyit.Geography.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class City : Entity<ModelState.City>
    {
        public City(ModelState.City state) : base(state)
        {
        }
    }
}
