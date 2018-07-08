using System.Collections.Generic;

namespace SpaceTrader.ModelState
{
    public class Member
    {
        public string Email { get; internal set; }
        public string Username { get; internal set; }
        public IList<Character> Characters { get; set; } = new List<Character>();
    }
}
