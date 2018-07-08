using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class Planet
    {
        public IList<City> Cities { get; set; } = new List<City>();
    }
}
