namespace Gamifyit.Game.Repositories
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;

    public abstract class GenericInMemoryEntityRepository<TEntity, TState>
        where TEntity : Entity<TState> 
        where TState : EntityState
    {
        private readonly ConcurrentDictionary<long, TState> states =
            new ConcurrentDictionary<long, TState>();

        private readonly EntityDictionary<TEntity, TState> entities;

        public GenericInMemoryEntityRepository()
        {

            this.entities = new EntityDictionary<TEntity, TState>(this.states, this.EntityFactory);
        }

        protected abstract TEntity EntityFactory(TState state);

        protected IReadOnlyDictionary<long, TEntity> Entities => this.entities;

        public async Task Add(TEntity gameType)
        {
            await Task.Run(
                () =>
                    {
                        gameType.Identity.SetIndex(this.states.Count + 1);
                        this.entities.Add(gameType);
                    });
        }

        public async Task<TEntity> Get(EntityIdentity identity)
        {
            return await Task.Run(
                       () =>
                           {
                               return this.entities.TryGetValue(identity.Index, out var gameType)
                                          ? gameType
                                          : default(TEntity);
                           });
        }
    }
}