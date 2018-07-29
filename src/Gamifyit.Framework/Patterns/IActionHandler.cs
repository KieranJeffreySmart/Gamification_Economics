namespace Gamifyit.Framework
{
    using System;
    using System.Threading.Tasks;

    public interface IActionHandler
    {
        Type Type { get; }

        Task Handle<TAction>(TAction action);
    }
}