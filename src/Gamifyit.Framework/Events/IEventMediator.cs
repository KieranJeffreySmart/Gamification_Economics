namespace Gamifyit.Framework.Events
{
    using System.Threading.Tasks;

    public interface IEventMediator
    {
        Task Register<TEvent>(IEventHandler<TEvent> handler) where TEvent : Event;
        Task Publish<TEvent>(TEvent publishedEvent) where TEvent : Event;
    }
}
