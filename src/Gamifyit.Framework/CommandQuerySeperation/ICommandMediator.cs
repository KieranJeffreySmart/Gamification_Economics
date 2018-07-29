namespace Gamifyit.Framework.CommandQuerySeperation
{
    using System;
    using System.Threading.Tasks;

    public interface ICommandMediator
    {
        Task Register(ICommandHandler handler);

        Task Execute<TCommand>(TCommand publishedEvent);
    }

    public interface ICommandHandler
    {
        Type CommandType { get; }

        Task Execute<TCommand>(TCommand publishedEvent);
    }
}