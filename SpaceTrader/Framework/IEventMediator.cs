using SpaceTrader.Framework.Events;
using System.Threading.Tasks;

namespace SpaceTrader.Framework
{
    public interface IEventMediator
    {
        Task Register<TEvent>(IEventHandler<TEvent> handler) where TEvent : Event;
        Task Publish<TEvent>(TEvent publishedEvent) where TEvent : Event;
    }
}
