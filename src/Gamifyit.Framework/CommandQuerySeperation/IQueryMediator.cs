namespace Gamifyit.Framework.CommandQuerySeperation
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;

    public interface IQueryMediator
    {
        Task Register(IQueryHandler handler);

        Task<TResult> Execute<TQuery, TResult>(TQuery publishedEvent);
    }

    public interface IQueryHandler
    {
        Type QueryType { get; }

        Task<TResult> Execute<TQuery, TResult>(TQuery publishedEvent);
    }
}