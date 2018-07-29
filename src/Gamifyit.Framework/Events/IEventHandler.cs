namespace Gamifyit.Framework.Events
{
    using System;
    using System.Threading.Tasks;
    
    public interface IEventHandler
    {
        Type EventType { get; }

        Task Handle<TEvent>(TEvent publishedEvent);
    }
}
