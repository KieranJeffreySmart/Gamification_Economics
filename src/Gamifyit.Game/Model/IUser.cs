namespace Gamifyit.Game.Model
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;

    public interface IUser
    {
        Task Register(string email, string username);

        EntityIdentity Identity { get; }
    }
}