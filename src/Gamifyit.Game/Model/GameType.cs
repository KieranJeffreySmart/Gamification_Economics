namespace Gamifyit.Game.Model
{
    using System.Collections.Generic;

    using Gamifyit.Framework.DomainObjects;

    public class GameType : Entity<ModelState.GameType>
    {

        public GameType(ModelState.GameType state)
            : base(state)
        {
        }
    }
}