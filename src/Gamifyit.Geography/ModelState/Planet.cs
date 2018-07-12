namespace Gamifyit.Geography.ModelState
{
    using System.Collections.Generic;

    public class Planet
    {
        public IList<City> Cities { get; set; } = new List<City>();
    }
}
