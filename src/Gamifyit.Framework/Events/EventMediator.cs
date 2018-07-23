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
                    if (registeredHandler.EventType.IsAssignableFrom(typeof(TEvent)))
                    {
                        registeredHandler.Handle(publishedEvent);
                    }
                }
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
