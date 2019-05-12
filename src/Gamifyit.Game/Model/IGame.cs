namespace Gamifyit.Game.Model
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;

    public interface IGame
    {
        EntityIdentity Identity { get; }

        GameType GameType { get; }

        Task StartNewGame();

        Task JoinAsPlayer(EntityIdentity characterIdentity);
    }
}