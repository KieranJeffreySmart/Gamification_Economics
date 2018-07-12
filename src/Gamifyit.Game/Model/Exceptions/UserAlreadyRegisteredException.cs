namespace Gamifyit.Game.Model.Exceptions
{
    public class UserAlreadyRegisteredException : System.Exception
    {
        public UserAlreadyRegisteredException() { }
        public UserAlreadyRegisteredException(string message) : base(message) { }
        public UserAlreadyRegisteredException(string message, System.Exception inner) : base(message, inner) { }
    }
}
