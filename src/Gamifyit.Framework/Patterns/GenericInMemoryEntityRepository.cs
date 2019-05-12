namespace Gamifyit.Framework.Patterns
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;



    public class GenericInMemoryEntityRepository<TEntity, TState> : IEntityRepository<TEntity, TState>
        where TEntity : Entity<TState> 
        where TState : EntityState
    {
        private readonly ConcurrentDictionary<long, TState> states =
            new ConcurrentDictionary<long, TState>();

        private Func<TState, TEntity> entityFactory;

        public GenericInMemoryEntityRepository(Func<TState, TEntity> entityFactory)
        {
            this.entityFactory = entityFactory;
        }
        
        public async Task Add(TEntity entity)
        {
            await Task.Run(
                () =>
                    {
                        entity.Identity.SetIndex(this.states.Count + 1);
                        if (string.IsNullOrWhiteSpace(entity.Identity.Reference))
                        {
                            entity.Identity.SetReference(Guid.NewGuid().ToString());
                        }

                        this.states.TryAdd(entity.Identity.Index, entity.CloneState());
                    });
        }

        public async Task<TEntity> Get(EntityIdentity identity)
        {
            return await Task.Run(
                       () => this.states.TryGetValue(identity.Index, out var gameType)
                                 ? this.entityFactory(gameType)
                                 : default(TEntity));
        }
        
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.Run(
                       () => this.states.Values.Select(this.entityFactory));
        }
    }
}