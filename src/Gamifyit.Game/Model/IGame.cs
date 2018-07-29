namespace Gamifyit.Game.Model
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;

    public interface IGame
    {
        EntityIdentity Identity { get; }

        Task StartNewGame();
    }
}