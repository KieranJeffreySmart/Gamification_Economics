namespace Gamifyit.Game.ModelState
{
    using System.Collections.Generic;

    public class Member
    {
        public string Email { get; internal set; }
        public string Username { get; internal set; }
        public IList<Character> Characters { get; set; } = new List<Character>();
    }
}
