namespace Gamifyit.Game.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;
    using Gamifyit.Game.Model;

    public class InMemoryCharacterRepository : GenericInMemoryEntityRepository<Character, ModelState.Character>, ICharacterRepository
    {
        protected override Character EntityFactory(ModelState.Character state)
        {
            return new Character(state);
        }
    }
}