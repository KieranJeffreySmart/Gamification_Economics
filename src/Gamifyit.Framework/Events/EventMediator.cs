namespace Gamifyit.Framework.Events
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventMediator : IEventMediator
    {
        private readonly List<IEventHandler> registeredHandlers = new List<IEventHandler>();

        public async Task Publish<TEvent>(TEvent publishedEvent) where TEvent : Event
        {
            await Task.Run(() =>
            {
                foreach (var registeredHandler in this.registeredHandlers)
                {
                    if (registeredHandler is IEventHandler<TEvent> handler)
                    {
                        handler.Handle(publishedEvent);
                    }
                }

                //var handlers = this.registeredHandlers.Where(h => typeof(TEvent).IsAssignableFrom(h.EventType));

                //foreach (var handler in handlers)
                //{
                //    handler.Handle(publishedEvent);
                //}
            });
        }

        public async Task Register<TEvent>(IEventHandler<TEvent> handler) where TEvent : Event
        {
            await Task.Run(() =>
            {
                this.registeredHandlers.Add(handler);
            });
        }
    }
}
