namespace Gamifyit.Framework.Patterns
{
    using System.Threading.Tasks;

    using Gamifyit.Framework.DomainObjects;

    public interface IEntityRepository<TEntity, TState>
        where TEntity : Entity<TState> where TState : EntityState
    {
        Task Add(TEntity entity);

        Task<TEntity> Get(EntityIdentity identity);
    }
}